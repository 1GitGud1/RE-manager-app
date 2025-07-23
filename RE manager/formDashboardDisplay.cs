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
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                if (selectedDate == DateTime.Today)
                {
                    var alerts = ctx.GetTodaysAlerts(selectedDate);
                    bindingSource1.DataSource = alerts;
                } else
                {
                    var alerts = ctx.GetAlerts(selectedDate);
                    bindingSource1.DataSource = alerts;
                }

            }

            dataGridView1.Refresh();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void formDashboardDisplay_Load(object sender, EventArgs e)
        {
            monthCalendar1.RemoveAllBoldedDates();
            foreach (var dt in GetEventTimes())
            {
                monthCalendar1.AddBoldedDate(dt);
            }
            monthCalendar1.UpdateBoldedDates();


            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            LoadData();

            dataGridView1.Columns[nameof(Alert.EventDate)].HeaderText = "Date";
            dataGridView1.Columns[nameof(Alert.Description)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void LoadData()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var alerts = ctx.GetTodaysAlerts(DateTime.Today);

                bindingSource1.DataSource = alerts;  
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private HashSet<DateTime> GetEventTimes()
        {
            using (var ctx = new PeopleContextFactory().CreateDbContext(null))
            {
                var today = DateTime.Today;

                var eventDates = new HashSet<DateTime>();

                // Add contract end dates
                eventDates.UnionWith(
                    ctx.Apartments2
                       .Where(a => a.ContractEndDate >= today)
                       .Select(a => a.ContractEndDate)
                );

                eventDates.UnionWith(
                ctx.ApartmentCheques2
                   .Where(c => !c.IsCashed)
                   .Select(c => c.DueDate.Date)
                );

                return eventDates;
            }
        }
    }
}
