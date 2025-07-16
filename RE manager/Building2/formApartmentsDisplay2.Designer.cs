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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(961, 564);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnViewServices
            // 
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
            dataGridView2.Location = new Point(967, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(389, 564);
            dataGridView2.TabIndex = 3;
            // 
            // formApartmentsDisplay2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 678);
            Controls.Add(dataGridView2);
            Controls.Add(btnViewServices);
            Controls.Add(dataGridView1);
            Name = "formApartmentsDisplay2";
            Text = "formApartmentsDisplay2";
            Load += formApartmentsDisplay2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Button btnViewServices;
        private DataGridView dataGridView2;
        private BindingSource bindingSource2;
    }
}