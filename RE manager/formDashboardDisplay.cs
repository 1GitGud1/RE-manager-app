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
    public partial class formDashboardDisplay : Form
    {
        public formDashboardDisplay()
        {
            InitializeComponent();
            monthCalendar1.Font = new Font(monthCalendar1.Font.FontFamily, 100f, monthCalendar1.Font.Style);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start.Date;

            dataGridView1.Refresh();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
