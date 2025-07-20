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
        public formApartmentPPMsDisplay2()
        {
            InitializeComponent();
        }

        private void formApartmentPPMsDisplay2_Load(object sender, EventArgs e)
        {
            EnsurePPMsExist();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            LoadData();

            dataGridView1.Columns["Apartment"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartmentPPMs = ctx.ApartmentPPMs2.ToList();

                bindingSource1.DataSource = apartmentPPMs;
            }
        }

        private void EnsurePPMsExist()
        {
            using var ctx = new PeopleContextFactory().CreateDbContext(null);

            var apartments = ctx.Apartments2
                                .Select(a => a.ApartmentNumber)
                                .ToList();

            var existingPPMs = ctx.Set<ApartmentPPM>()
                                  .Select(p => p.ApartmentNumber)
                                  .ToList();

            var missing = apartments.Except(existingPPMs).ToList();

            if (missing.Any())
            {
                var newPPMs = missing.Select(apNum => new ApartmentPPM
                {
                    ApartmentNumber = apNum,
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
    }
}
