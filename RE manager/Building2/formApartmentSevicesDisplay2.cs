using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RE_manager
{
    public partial class formApartmentSevicesDisplay2 : Form
    {
        private readonly int _apartmentNumber;
        private readonly int _buildingNumber;

        DateTimePicker _datePicker = new DateTimePicker();
        Rectangle _dateRect = new Rectangle();
        public formApartmentSevicesDisplay2(int apartmentNumber, int buildingNumber)
        {
            InitializeComponent();
            _apartmentNumber = apartmentNumber;
            _buildingNumber = buildingNumber;

            dataGridView1.Controls.Add(_datePicker);
            _datePicker.Visible = false;
            _datePicker.Format = DateTimePickerFormat.Custom;
            _datePicker.TextChanged += new EventHandler(_datePicker_TextChange);
        }

        private void _datePicker_TextChange(Object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = _datePicker.Text.ToString();
        }

        private void formApartmentSevicesDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
            LoadData();
            dataGridView1.Columns["ApartmentNumber"].Visible = false;
            dataGridView1.Columns["BuildingNumber"].Visible = false;
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var services = ctx.ApartmentServices2
                    .Where(s => s.ApartmentNumber == _apartmentNumber && s.BuildingNumber == _buildingNumber)
                    .OrderBy(s => s.ServiceDate)
                    .ToList();

                bindingSource1.DataSource = services;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is ApartmentService edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.ApartmentNumber = _apartmentNumber;
                    edited.BuildingNumber = _buildingNumber;
                    ctx.ApartmentServices2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void formApartmentSevicesDisplay2_Resize(object sender, EventArgs e)
        {
            _datePicker.Visible = false;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            _datePicker.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {
                    case "ServiceDate":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    default:
                        _datePicker.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                _datePicker.Visible = false;
            }
        }
    }
}
