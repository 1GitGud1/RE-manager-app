using RE_manager.Building1;
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
    public partial class formBuilding : Form
    {
        formDashboard dashboard;
        Form currentDisplay;
        public formBuilding()
        {
            InitializeComponent();
        }

        private void formBuilding_Load(object sender, EventArgs e)
        {
            formApartmentsDisplay apartmentsDisplay = new formApartmentsDisplay(this) { TopLevel = false, TopMost = true };
            apartmentsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(apartmentsDisplay);
            apartmentsDisplay.Show();
            currentDisplay = apartmentsDisplay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formApartmentsDisplay apartmentsDisplay = new formApartmentsDisplay(this) { TopLevel = false, TopMost = true };
            apartmentsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(apartmentsDisplay);
            apartmentsDisplay.Show();
            currentDisplay = apartmentsDisplay;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formPPMsDisplay ppmsDisplay = new formPPMsDisplay() { TopLevel = false, TopMost = true };
            ppmsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(ppmsDisplay);
            ppmsDisplay.Show();
            currentDisplay = ppmsDisplay;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formContractsDisplay contractsDisplay = new formContractsDisplay() { TopLevel = false, TopMost = true };
            contractsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(contractsDisplay);
            contractsDisplay.Show();
            currentDisplay = contractsDisplay;
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
            currentDisplay = form;
        }
    }
}
