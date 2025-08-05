namespace RE_manager
{
    partial class formApartmentsDisplay2
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
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            btnViewServices = new Button();
            dataGridView2 = new DataGridView();
            bindingSource2 = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(956, 558);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnViewServices
            // 
            btnViewServices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewServices.Enabled = false;
            btnViewServices.Location = new Point(12, 570);
            btnViewServices.Name = "btnViewServices";
            btnViewServices.Size = new Size(175, 29);
            btnViewServices.TabIndex = 1;
            btnViewServices.Text = "View Service Log";
            btnViewServices.UseVisualStyleBackColor = true;
            btnViewServices.Click += btnViewServices_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(965, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(388, 558);
            dataGridView2.TabIndex = 3;
            dataGridView2.RowValidated += dataGridView2_RowValidated;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(193, 570);
            button1.Name = "button1";
            button1.Size = new Size(175, 29);
            button1.TabIndex = 4;
            button1.Text = "AC Cleaning";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.Location = new Point(786, 570);
            button2.Name = "button2";
            button2.Size = new Size(175, 29);
            button2.TabIndex = 5;
            button2.Text = "Delete Record";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView2, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1356, 564);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // formApartmentsDisplay2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 678);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnViewServices);
            Controls.Add(tableLayoutPanel1);
            Name = "formApartmentsDisplay2";
            Text = "formApartmentsDisplay2";
            Load += formApartmentsDisplay2_Load;
            Resize += formApartmentsDisplay2_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Button btnViewServices;
        private DataGridView dataGridView2;
        private BindingSource bindingSource2;
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
    }
}