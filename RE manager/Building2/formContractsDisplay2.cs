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
        public formContractsDisplay2(int buildingNumber)
        {
            InitializeComponent();
            _buildingNumber = buildingNumber;
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
    }
}
