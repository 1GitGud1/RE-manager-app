using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RE_manager.Building2;
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
        private int _apartmentNumber;
        public formApartmentsDisplay2()
        {
            InitializeComponent();
        }

        private formBuilding2 building2 = null;
        public formApartmentsDisplay2(Form callingForm)
        {
            building2 = callingForm as formBuilding2;
            InitializeComponent();
        }

        private void formApartmentsDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["PPM"].Visible = false;

            dataGridView2.Columns["ApartmentNumber"].Visible = false;
            dataGridView2.Columns["Id"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartments = ctx.Apartments2.ToList();

                bindingSource1.DataSource = apartments;
            }
        }

        private void LoadCheques(int _apartmentNumber)
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var cheques = ctx.ApartmentCheques2
                    .Where(s => s.ApartmentNumber == _apartmentNumber)
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



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnViewServices.Enabled = (dataGridView1.CurrentRow != null);

            if (dataGridView1.CurrentRow?.DataBoundItem is Apartment apt)
            {
                _apartmentNumber = apt.ApartmentNumber;
                LoadCheques(apt.ApartmentNumber);
            }
        }

        private void btnViewServices_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Apartment apt)
            {
                this.Hide();
                formApartmentSevicesDisplay2 apartmentServicesDisplay = new formApartmentSevicesDisplay2(apt.ApartmentNumber) { TopLevel = false, TopMost = true };
                apartmentServicesDisplay.FormBorderStyle = FormBorderStyle.None;
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
                    ctx.ApartmentCheques2.Update(edited);
                    ctx.SaveChanges();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formApartmentPPMsDisplay2 apartmentPPMsDisplay = new formApartmentPPMsDisplay2() { TopLevel = false, TopMost = true };
            apartmentPPMsDisplay.FormBorderStyle = FormBorderStyle.None;
            building2.LoadFormInPanel(apartmentPPMsDisplay);
        }
    }
}

