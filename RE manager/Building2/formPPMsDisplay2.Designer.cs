namespace RE_manager.Building2
{
    partial class formPPMsDisplay2
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
            dataGridView2 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            bindingSource2 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(961, 678);
            dataGridView1.TabIndex = 2;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(967, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(389, 678);
            dataGridView2.TabIndex = 5;
            dataGridView2.RowValidated += dataGridView2_RowValidated;
            // 
            // formPPMsDisplay2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 678);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "formPPMsDisplay2";
            Text = "formPPMsDisplay2";
            Load += formPPMsDisplay2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
    }
}