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
    public partial class formDashboard : Form
    {
        formBuilding2 building2;
        public formDashboard()
        {
            InitializeComponent();

        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            formDashboardDisplay dashboardDisplay = new formDashboardDisplay() { TopLevel = false, TopMost = true };
            dashboardDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(dashboardDisplay);
            dashboardDisplay.Show();
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 55)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 250)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnBuilding1.Width = sidebar.Width;
                    pnBuilding2.Width = sidebar.Width;
                    pnBuilding3.Width = sidebar.Width;
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (building2 == null)
            {
                building2 = new formBuilding2();
                building2.FormClosed += Building2_FormClosed;
                building2.MdiParent = this.MdiParent;
                building2.Dock = DockStyle.Fill;
                building2.Show();
            }
            else
            {
                building2.Activate();
            }
        }

        private void Building2_FormClosed(object? sender, FormClosedEventArgs e)
        {
            building2 = null;
        }
    }
}
