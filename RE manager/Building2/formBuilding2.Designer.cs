namespace RE_manager
{
    partial class formBuilding2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBuilding2));
            panel1 = new Panel();
            lblHelloWorld = new Label();
            btnHam = new PictureBox();
            sidebar = new FlowLayoutPanel();
            pnBuilding2 = new Panel();
            button1 = new Button();
            pnBuilding1 = new Panel();
            button2 = new Button();
            pnBuilding3 = new Panel();
            button3 = new Button();
            panel3 = new Panel();
            button4 = new Button();
            parentPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            sidebar.SuspendLayout();
            pnBuilding2.SuspendLayout();
            pnBuilding1.SuspendLayout();
            pnBuilding3.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(lblHelloWorld);
            panel1.Controls.Add(btnHam);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1374, 39);
            panel1.TabIndex = 1;
            // 
            // lblHelloWorld
            // 
            lblHelloWorld.AutoSize = true;
            lblHelloWorld.Location = new Point(59, 9);
            lblHelloWorld.Name = "lblHelloWorld";
            lblHelloWorld.Size = new Size(76, 20);
            lblHelloWorld.TabIndex = 2;
            lblHelloWorld.Text = "Building 2";
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(12, 7);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(30, 25);
            btnHam.SizeMode = PictureBoxSizeMode.StretchImage;
            btnHam.TabIndex = 6;
            btnHam.TabStop = false;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(23, 24, 29);
            sidebar.Controls.Add(pnBuilding2);
            sidebar.Controls.Add(pnBuilding1);
            sidebar.Controls.Add(pnBuilding3);
            sidebar.Controls.Add(panel3);
            sidebar.Dock = DockStyle.Left;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new Point(0, 39);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 25, 0, 0);
            sidebar.Size = new Size(250, 686);
            sidebar.TabIndex = 7;
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
            button1.Text = "                Tenants";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            button2.Text = "                PPMs";
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
            button3.Text = "                Contracts";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(button4);
            panel3.Location = new Point(3, 193);
            panel3.Name = "panel3";
            panel3.Size = new Size(247, 49);
            panel3.TabIndex = 9;
            // 
            // button4
            // 
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.BackColor = Color.FromArgb(23, 24, 29);
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(-14, -25);
            button4.Name = "button4";
            button4.Padding = new Padding(20, 0, 0, 10);
            button4.Size = new Size(282, 104);
            button4.TabIndex = 6;
            button4.Text = "                Dashboard";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // parentPanel
            // 
            parentPanel.Dock = DockStyle.Fill;
            parentPanel.Location = new Point(250, 39);
            parentPanel.Name = "parentPanel";
            parentPanel.Size = new Size(1124, 686);
            parentPanel.TabIndex = 8;
            // 
            // formBuilding2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 725);
            Controls.Add(parentPanel);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formBuilding2";
            Text = "formBuilding2";
            Load += formBuilding2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            sidebar.ResumeLayout(false);
            pnBuilding2.ResumeLayout(false);
            pnBuilding1.ResumeLayout(false);
            pnBuilding3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblHelloWorld;
        private PictureBox btnHam;
        private FlowLayoutPanel sidebar;
        private Panel pnBuilding2;
        private Button button1;
        private Panel pnBuilding1;
        private Button button2;
        private Panel pnBuilding3;
        private Button button3;
        private Panel parentPanel;
        private Panel panel3;
        private Button button4;
    }
}