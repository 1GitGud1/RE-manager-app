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
    public partial class formBuilding2 : Form
    {
        formDashboard dashboard;
        Form currentDisplay;
        public int _buildingNumber;

        public formBuilding2(int buildingNumber)
        {
            InitializeComponent();
            _buildingNumber = buildingNumber;
            lblHelloWorld.Text = ("Building " + buildingNumber);
        }

        private void formBuilding2_Load(object sender, EventArgs e)
        {
            formApartmentsDisplay2 apartmentsDisplay = new formApartmentsDisplay2(this) { TopLevel = false, TopMost = true };
            apartmentsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(apartmentsDisplay);
            apartmentsDisplay.Show();
            currentDisplay = apartmentsDisplay;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formApartmentsDisplay2 apartmentsDisplay = new formApartmentsDisplay2(this) { TopLevel = false, TopMost = true };
            apartmentsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(apartmentsDisplay);
            apartmentsDisplay.Show();
            currentDisplay = apartmentsDisplay;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formPPMsDisplay2 ppmsDisplay = new formPPMsDisplay2(_buildingNumber) { TopLevel = false, TopMost = true };
            ppmsDisplay.FormBorderStyle = FormBorderStyle.None;
            parentPanel.Controls.Add(ppmsDisplay);
            ppmsDisplay.Show();
            currentDisplay = ppmsDisplay;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentDisplay.Hide();
            formContractsDisplay2 contractsDisplay = new formContractsDisplay2(_buildingNumber) { TopLevel = false, TopMost = true };
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
