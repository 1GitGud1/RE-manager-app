using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RE_manager.Building2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RE_manager
{
    public partial class formApartmentsDisplay2 : Form
    {
        private int _apartmentNumber;
        private int _buildingNumber;
        bool isFirstRecord;

        private double _buttonXRatio;

        DateTimePicker _datePicker = new DateTimePicker();
        DateTimePicker _datePicker2 = new DateTimePicker();
        Rectangle _dateRect = new Rectangle();
        public formApartmentsDisplay2()
        {
            InitializeComponent();
        }

        private formBuilding2 building2 = null;
        public formApartmentsDisplay2(Form callingForm)
        {
            building2 = callingForm as formBuilding2;
            _buildingNumber = building2._buildingNumber;
            InitializeComponent();

            _buttonXRatio = 0.71;//(double)button2.Left / this.ClientSize.Width;

            dataGridView1.MultiSelect = false;

            //setting up date picker
            dataGridView1.Controls.Add(_datePicker);
            dataGridView2.Controls.Add(_datePicker2);
            _datePicker.Visible = false;
            _datePicker.Format = DateTimePickerFormat.Custom;
            _datePicker.TextChanged += new EventHandler(_datePicker_TextChange);
            _datePicker2.Visible = false;
            _datePicker2.Format = DateTimePickerFormat.Custom;
            _datePicker2.TextChanged += new EventHandler(_datePicker2_TextChange);
        }

        private void _datePicker_TextChange(Object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = _datePicker.Text.ToString();
        }

        private void _datePicker2_TextChange(Object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = _datePicker2.Text.ToString();
        }

        private void formApartmentsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["PPM"].Visible = false;
            dataGridView1.Columns["BuildingNumber"].Visible = false;

            if (dataGridView1.Rows.Count > 1)
            {
                dataGridView2.Columns["ApartmentNumber"].Visible = false;
                dataGridView2.Columns["Id"].Visible = false;
                dataGridView2.Columns["BuildingNumber"].Visible = false;
            } else
            {
                isFirstRecord = true;
            }
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartments = ctx.Apartments2
                    .Where(b => b.BuildingNumber == _buildingNumber)
                    .ToList();

                bindingSource1.DataSource = apartments;
            }
        }

        private void LoadCheques(int _apartmentNumber)
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var cheques = ctx.ApartmentCheques2
                    .Where(s => s.ApartmentNumber == _apartmentNumber && s.BuildingNumber == _buildingNumber)
                    .OrderBy(s => s.DueDate)
                    .ToList();

                bindingSource2.DataSource = cheques;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is Apartment edited)
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.BuildingNumber = _buildingNumber;
                    bool exists = ctx.Apartments2
                        .AsNoTracking()
                        .Any(a => a.ApartmentNumber == edited.ApartmentNumber && a.BuildingNumber == edited.BuildingNumber);

                    if (!exists)
                    {
                        // New or renumbered apartment → just Add()
                        ctx.Apartments2.Add(edited);
                    }
                    else
                    {
                        // Truly updating an existing apartment
                        ctx.Apartments2.Update(edited);
                    }

                    ctx.SaveChanges();
                }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnViewServices.Enabled = (dataGridView1.CurrentRow != null);

            if (dataGridView1.CurrentRow?.DataBoundItem is Apartment apt)
            {
                _apartmentNumber = apt.ApartmentNumber;
                LoadCheques(apt.ApartmentNumber);

                if (isFirstRecord)
                {
                    isFirstRecord = false;
                    dataGridView2.Columns["ApartmentNumber"].Visible = false;
                    dataGridView2.Columns["Id"].Visible = false;
                    dataGridView2.Columns["BuildingNumber"].Visible = false;
                }
            }
        }

        private void btnViewServices_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Apartment apt)
            {
                this.Hide();
                formApartmentSevicesDisplay2 apartmentServicesDisplay = new formApartmentSevicesDisplay2(apt.ApartmentNumber, apt.BuildingNumber) { TopLevel = false, TopMost = true };
                apartmentServicesDisplay.FormBorderStyle = FormBorderStyle.None;
                apartmentServicesDisplay.Dock = DockStyle.Fill;
                building2.LoadFormInPanel(apartmentServicesDisplay);
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource2.Current is ApartmentCheque edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.ApartmentNumber = _apartmentNumber;
                    edited.BuildingNumber = _buildingNumber;
                    ctx.ApartmentCheques2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formApartmentPPMsDisplay2 apartmentPPMsDisplay = new formApartmentPPMsDisplay2(_buildingNumber) { TopLevel = false, TopMost = true };
            apartmentPPMsDisplay.FormBorderStyle = FormBorderStyle.None;
            apartmentPPMsDisplay.Dock = DockStyle.Fill;
            building2.LoadFormInPanel(apartmentPPMsDisplay);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Apartment apt)
            {
                var result = MessageBox.Show($"Delete apartment {apt.ApartmentNumber}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    ctx.Remove(apt);
                    ctx.SaveChanges();
                    bindingSource1.Remove(apt);
                }
            }
        }

        private void formApartmentsDisplay2_Resize(object sender, EventArgs e)
        {
            //Moves the delete button when window is resized
            int newX = (int)(this.ClientSize.Width * _buttonXRatio) - 177;
            button2.Location = new Point(newX, button2.Location.Y);

            _datePicker.Visible = false;
            _datePicker2.Visible = false;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            _datePicker.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _datePicker2.Visible = false;
            try
            {
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {
                    case "ContractStartDate":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    case "ContractEndDate":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    default:
                        _datePicker.Visible = false;
                        break;
                }
            } catch (Exception ex)
            {
                _datePicker.Visible = false;
            }
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            _datePicker2.Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _datePicker.Visible = false;
            try 
            { 
                switch (dataGridView2.Columns[e.ColumnIndex].Name)
                {
                    case "DueDate":
                        _dateRect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker2.Size = new Size(19, _dateRect.Height);
                        _datePicker2.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker2.Visible = true;
                        break;

                    default:
                        _datePicker2.Visible = false;
                        break;
                }
            } catch (Exception ex)
            {
                _datePicker2.Visible = false;
            }
        }
    }
}

