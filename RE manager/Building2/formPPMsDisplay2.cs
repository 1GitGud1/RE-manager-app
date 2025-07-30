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
        public formPPMsDisplay2(int buildingNumber)
        {
            InitializeComponent();
            _buildingNumber = buildingNumber;
        }

        private void formPPMsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["PPMId"].Visible = false;

            if (dataGridView1.CurrentRow?.DataBoundItem is PPM ppm)
            {
                dataGridView2.Columns["PPMId"].Visible = false;
                dataGridView2.Columns["Id"].Visible = false;
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
    }
}
