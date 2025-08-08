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
    public partial class formContractsDisplay2 : Form
    {
        int _buildingNumber;
        int _contractNumber;
        bool isFirstRecord;

        DateTimePicker _datePicker = new DateTimePicker();
        DateTimePicker _datePicker2 = new DateTimePicker();
        Rectangle _dateRect = new Rectangle();
        public formContractsDisplay2(int buildingNumber)
        {
            InitializeComponent();
            _buildingNumber = buildingNumber;

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

        private void formContractsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["ContractId"].Visible = false;
            dataGridView1.Columns["BuildingNumber"].Visible = false;
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dataGridView1.Rows.Count > 1)
            {
                dataGridView2.Columns["ContractId"].Visible = false;
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
                var contracts = ctx.Contracts2
                    .Where(c => c.BuildingNumber == _buildingNumber)
                    .ToList();

                bindingSource1.DataSource = contracts;
            }
        }

        private void LoadDues(int _contractNumber)
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var dues = ctx.ContractDues2
                    .Where(s => s.ContractId == _contractNumber)
                    .OrderBy(s => s.DueDate)
                    .ToList();

                bindingSource2.DataSource = dues;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is Contract edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.BuildingNumber = _buildingNumber;
                    ctx.Contracts2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Contract contract)
            {
                _contractNumber = contract.ContractId;
                LoadDues(_contractNumber);

                if (isFirstRecord)
                {
                    isFirstRecord = false;
                    dataGridView2.Columns["ContractId"].Visible = false;
                    dataGridView2.Columns["Id"].Visible = false;
                }
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource2.Current is ContractDue edited)
            {
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    edited.ContractId = _contractNumber;
                    ctx.ContractDues2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void formContractsDisplay2_Resize(object sender, EventArgs e)
        {
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
                    case "StartDate":
                        _dateRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        _datePicker.Size = new Size(19, _dateRect.Height);
                        _datePicker.Location = new Point(_dateRect.X + _dateRect.Width - 20, _dateRect.Y);
                        _datePicker.Visible = true;
                        break;

                    case "EndDate":
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
            }
            catch (Exception ex)
            {
                _datePicker2.Visible = false;
            }
        }
    }
}
