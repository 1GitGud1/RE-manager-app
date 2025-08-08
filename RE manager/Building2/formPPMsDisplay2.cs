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
    public partial class formPPMsDisplay2 : Form
    {
        int _buildingNumber;
        int _ppmNumber;
        bool isFirstRecord;

        DateTimePicker _datePicker2 = new DateTimePicker();
        Rectangle _dateRect = new Rectangle();
        public formPPMsDisplay2(int buildingNumber)
        {
            InitializeComponent();
            _buildingNumber = buildingNumber;

            //setting up date picker
            dataGridView2.Controls.Add(_datePicker2);
            _datePicker2.Visible = false;
            _datePicker2.Format = DateTimePickerFormat.Custom;
            _datePicker2.TextChanged += new EventHandler(_datePicker2_TextChange);
        }

        private void _datePicker2_TextChange(Object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = _datePicker2.Text.ToString();
        }

        private void formPPMsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["PPMId"].Visible = false;
            dataGridView1.Columns["BuildingNumber"].Visible = false;
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dataGridView1.Rows.Count > 1)
            {
                dataGridView2.Columns["PPMId"].Visible = false;
                dataGridView2.Columns["Id"].Visible = false;
            }
            else
            {
                isFirstRecord = true;
            }
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var ppms = ctx.PPMs2
                    .Where(p => p.BuildingNumber == _buildingNumber)
                    .ToList();

                bindingSource1.DataSource = ppms;
            }
        }

        private void LoadTimes(int _ppmNumber)
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var times = ctx.PPMtimes2
                    .Where(s => s.PPMId == _ppmNumber)
                    .OrderBy(s => s.StartDate)
                    .ToList();

                bindingSource2.DataSource = times;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is PPM edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.BuildingNumber = _buildingNumber;
                    ctx.PPMs2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is PPM ppm)
            {
                _ppmNumber = ppm.PPMId;
                LoadTimes(_ppmNumber);
                if (isFirstRecord)
                {
                    isFirstRecord = false;
                    dataGridView2.Columns["PPMId"].Visible = false;
                    dataGridView2.Columns["Id"].Visible = false;
                }
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource2.Current is PPMtime edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.PPMId = _ppmNumber;
                    ctx.PPMtimes2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void formPPMsDisplay2_Resize(object sender, EventArgs e)
        {
            _datePicker2.Visible = false;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            _datePicker2.Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dataGridView2.Columns[e.ColumnIndex].Name)
                {
                    case "StartDate":
                        _dateRect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker2.Size = new Size(19, _dateRect.Height);
                        _datePicker2.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker2.Visible = true;
                        break;

                    case "EndDate":
                        _dateRect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker2.Size = new Size(19, _dateRect.Height);
                        _datePicker2.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker2.Visible = true;
                        break;

                    default:
                        _datePicker2.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                _datePicker2.Visible = false;
            }
        }
    }
}
