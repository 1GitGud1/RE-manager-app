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
    public partial class formBuilding2 : Form
    {
        formDashboard dashboard;

        public formBuilding2()
        {
            InitializeComponent();
        }

        private void formBuilding2_Load(object sender, EventArgs e)
        {
            formApartmentsDisplay2 apartmentsDisplay = new formApartmentsDisplay2(this) { TopLevel = false, TopMost = true };
            apartmentsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(apartmentsDisplay);
            apartmentsDisplay.Show();   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this.MdiParent;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
        }

        private void Dashboard_FormClosed(object? sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        public void LoadFormInPanel(Form form)
        {
            parentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
