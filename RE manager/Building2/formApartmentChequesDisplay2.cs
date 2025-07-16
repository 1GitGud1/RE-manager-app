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

namespace RE_manager.Building2
{
    public partial class formApartmentChequesDisplay2 : Form
    {
        private readonly int _apartmentNumber;
        public formApartmentChequesDisplay2(int apartmentNumber)
        {
            InitializeComponent();
            _apartmentNumber = apartmentNumber;
        }

        private void formApartmentChequesDisplay2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
            LoadData();
            dataGridView1.Columns["ApartmentNumber"].Visible = false;
        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var cheques = ctx.ApartmentCheques2
                    .Where(s => s.ApartmentNumber == _apartmentNumber)
                    .OrderBy(s => s.DueDate)
                    .ToList();

                bindingSource1.DataSource = cheques;
            }
        }
    }
}
