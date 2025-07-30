using EFDataAccessLibrary.DataAccess;
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
    public partial class formApartmentsDisplay : Form
    {
        private int _apartmentNumber;
        public formApartmentsDisplay()
        {
            InitializeComponent();
        }

        private formBuilding building = null;
        public formApartmentsDisplay(Form callingForm)
        {
            building = callingForm as formBuilding;
            InitializeComponent();
        }

        private void formApartmentsDisplay_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource2;

            LoadData();

            dataGridView1.Columns["PPM"].Visible = false;

            //dataGridView2.Columns["ApartmentNumber"].Visible = false;
            //dataGridView2.Columns["Id"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var apartments = ctx.Apartments2.ToList();

                bindingSource1.DataSource = apartments;
            }
        }
    }
}
