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

namespace RE_manager.Building2
{
    public partial class formApartmentPPMsDisplay2 : Form
    {
        private readonly int _buildingNumber;

        DateTimePicker _datePicker = new DateTimePicker();
        Rectangle _dateRect = new Rectangle();
        public formApartmentPPMsDisplay2(int buildingNumber)
        {
            InitializeComponent();
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

        private void formApartmentPPMsDisplay2_Load(object sender, EventArgs e)
        {
            EnsurePPMsExist();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            LoadData();

            dataGridView1.Columns["Apartment"].Visible = false;
            dataGridView1.Columns["BuildingNumber"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartmentPPMs = ctx.ApartmentPPMs2
                    .Where(a => a.BuildingNumber == _buildingNumber)
                    .ToList();

                bindingSource1.DataSource = apartmentPPMs;
            }
        }

        private void EnsurePPMsExist()
        {
            using var ctx = new PeopleContextFactory().CreateDbContext(null);

            var apartments = ctx.Apartments2
                                .Where(a => a.BuildingNumber == _buildingNumber)
                                .Select(a => a.ApartmentNumber)
                                .ToList();

            var existingPPMs = ctx.Set<ApartmentPPM>()
                                .Where(a => a.BuildingNumber == _buildingNumber)
                                .Select(p => p.ApartmentNumber)
                                .ToList();

            var missing = apartments.Except(existingPPMs).ToList();

            if (missing.Any())
            {
                var newPPMs = missing.Select(apNum => new ApartmentPPM
                {
                    ApartmentNumber = apNum,
                    BuildingNumber = _buildingNumber,
                    // initialize other fields with defaults if necessary
                }).ToList();

                ctx.AddRange(newPPMs);
                ctx.SaveChanges();
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is ApartmentPPM edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    ctx.ApartmentPPMs2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void formApartmentPPMsDisplay2_Resize(object sender, EventArgs e)
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
                    case "Q1Date":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    case "Q2Date":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    case "Q3Date":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    case "Q4Date":
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
