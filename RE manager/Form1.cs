
namespace RE_manager;
public partial class Form1 : Form
{

    //formBuilding2 building2Form;
    formDashboard dashboard;
    formBuilding2 building2Form;

    public Form1()
    {
        InitializeComponent();
        //formBuilding11.Hide();

        if (dashboard == null)
        {
            dashboard = new formDashboard();
            dashboard.FormClosed += Dashboard_FormClosed;
            dashboard.MdiParent = this;
            dashboard.Dock = DockStyle.Fill;
            dashboard.Show();
        }
        else
        {
            dashboard.Activate();
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        
    }

    private void Dashboard_FormClosed(object? sender, FormClosedEventArgs e)
    {
        dashboard = null;
    }

    //bool sidebarExpand = true;
    //private void sidebarTransition_Tick(object sender, EventArgs e)
    //{
    //    if (sidebarExpand)
    //    {
    //        sidebar.Width -= 10;
    //        if (sidebar.Width <= 55)
    //        {
    //            sidebarExpand = false;
    //            sidebarTransition.Stop();
    //        }
    //    }
    //    else
    //    {
    //        sidebar.Width += 10;
    //        if (sidebar.Width >= 250)
    //        {
    //            sidebarExpand = true;
    //            sidebarTransition.Stop();

    //            pnBuilding1.Width = sidebar.Width;
    //            pnBuilding2.Width = sidebar.Width;
    //            pnBuilding3.Width = sidebar.Width;
    //        }
    //    }
    //}

    //private void btnHam_Click(object sender, EventArgs e)
    //{
    //    sidebarTransition.Start();

    //}

    //private void button1_Click(object sender, EventArgs e)
    //{
    //    formBuilding11.Show();
    //    formBuilding11.BringToFront();
    //}

    //private void button2_Click(object sender, EventArgs e)
    //{
    //    this.Hide();
    //    formBuilding2 formBuilding21 = new formBuilding2();
    //    formBuilding21.Show();
    //if (building2Form == null)
    //{
    //    building2Form = new formBuilding2();
    //    building2Form.FormClosed += Building2Form_FormClosed;
    //    building2Form.MdiParent = this;
    //    building2Form.Dock = DockStyle.Fill;
    //    building2Form.Show();
    //}
    //else
    //{
    //    building2Form.Activate();
    //}
    //}

    //private void Building2Form_FormClosed(object? sender, FormClosedEventArgs e)
    //{
    //    building2Form = null;
    //}
}
