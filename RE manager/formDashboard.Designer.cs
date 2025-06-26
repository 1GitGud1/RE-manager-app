namespace RE_manager
{
    partial class formDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDashboard));
            panel1 = new Panel();
            btnHam = new PictureBox();
            lblHelloWorld = new Label();
            sidebar = new FlowLayoutPanel();
            pnBuilding2 = new Panel();
            button1 = new Button();
            pnBuilding1 = new Panel();
            button2 = new Button();
            pnBuilding3 = new Panel();
            button3 = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            parentPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            sidebar.SuspendLayout();
            pnBuilding2.SuspendLayout();
            pnBuilding1.SuspendLayout();
            pnBuilding3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(btnHam);
            panel1.Controls.Add(lblHelloWorld);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 39);
            panel1.TabIndex = 5;
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(12, 7);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(30, 25);
            btnHam.SizeMode = PictureBoxSizeMode.StretchImage;
            btnHam.TabIndex = 5;
            btnHam.TabStop = false;
            btnHam.Click += btnHam_Click;
            // 
            // lblHelloWorld
            // 
            lblHelloWorld.AutoSize = true;
            lblHelloWorld.Location = new Point(59, 9);
            lblHelloWorld.Name = "lblHelloWorld";
            lblHelloWorld.Size = new Size(82, 20);
            lblHelloWorld.TabIndex = 1;
            lblHelloWorld.Text = "Dashboard";
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(23, 24, 29);
            sidebar.Controls.Add(pnBuilding2);
            sidebar.Controls.Add(pnBuilding1);
            sidebar.Controls.Add(pnBuilding3);
            sidebar.Dock = DockStyle.Left;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new Point(0, 39);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 25, 0, 0);
            sidebar.Size = new Size(250, 670);
            sidebar.TabIndex = 6;
            // 
            // pnBuilding2
            // 
            pnBuilding2.Controls.Add(button1);
            pnBuilding2.Location = new Point(3, 28);
            pnBuilding2.Name = "pnBuilding2";
            pnBuilding2.Size = new Size(247, 49);
            pnBuilding2.TabIndex = 7;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.FromArgb(23, 24, 29);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(-14, -25);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 10);
            button1.Size = new Size(282, 104);
            button1.TabIndex = 6;
            button1.Text = "                Building 1";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // pnBuilding1
            // 
            pnBuilding1.Controls.Add(button2);
            pnBuilding1.Location = new Point(3, 83);
            pnBuilding1.Name = "pnBuilding1";
            pnBuilding1.Size = new Size(247, 49);
            pnBuilding1.TabIndex = 8;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = Color.FromArgb(23, 24, 29);
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(-14, -25);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 10);
            button2.Size = new Size(282, 104);
            button2.TabIndex = 6;
            button2.Text = "                Building 2";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pnBuilding3
            // 
            pnBuilding3.Controls.Add(button3);
            pnBuilding3.Location = new Point(3, 138);
            pnBuilding3.Name = "pnBuilding3";
            pnBuilding3.Size = new Size(247, 49);
            pnBuilding3.TabIndex = 8;
            // 
            // button3
            // 
            button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button3.BackColor = Color.FromArgb(23, 24, 29);
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(-14, -25);
            button3.Name = "button3";
            button3.Padding = new Padding(20, 0, 0, 10);
            button3.Size = new Size(282, 104);
            button3.TabIndex = 6;
            button3.Text = "                Building 3";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // parentPanel
            // 
            parentPanel.Dock = DockStyle.Fill;
            parentPanel.Location = new Point(250, 39);
            parentPanel.Name = "parentPanel";
            parentPanel.Size = new Size(1021, 670);
            parentPanel.TabIndex = 7;
            // 
            // formDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 709);
            Controls.Add(parentPanel);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formDashboard";
            Text = "formDashboard";
            Load += formDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            sidebar.ResumeLayout(false);
            pnBuilding2.ResumeLayout(false);
            pnBuilding1.ResumeLayout(false);
            pnBuilding3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btnHam;
        private Label lblHelloWorld;
        private FlowLayoutPanel sidebar;
        private Panel pnBuilding2;
        private Button button1;
        private Panel pnBuilding1;
        private Button button2;
        private Panel pnBuilding3;
        private Button button3;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel parentPanel;
    }
}