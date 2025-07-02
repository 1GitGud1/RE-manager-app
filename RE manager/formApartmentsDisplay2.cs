using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class formApartmentsDisplay2 : Form
    {
        public formApartmentsDisplay2()
        {
            InitializeComponent();
        }

        private void formApartmentsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            LoadData();
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartments = ctx.Apartments2.ToList();

                bindingSource1.DataSource = apartments;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSource1.Current is Apartment edited)
                using (var ctx = new PeopleContextFactory().CreateDbContext(null))
                {
                    bool exists = ctx.Apartments2
                 .AsNoTracking()
                 .Any(a => a.ApartmentNumber == edited.ApartmentNumber);

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
    }
}

