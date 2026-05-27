namespace CK_OS_2026
{
    partial class Deadlock_Input
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deadlock_Input));
            label1 = new Label();
            txtProcess = new TextBox();
            label2 = new Label();
            txtResource = new TextBox();
            dgvInstance = new DataGridView();
            label3 = new Label();
            dgvAllocation = new DataGridView();
            label4 = new Label();
            dgvMax = new DataGridView();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInstance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMax).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 38);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 0;
            label1.Text = "Nhập số Process";
            // 
            // txtProcess
            // 
            txtProcess.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProcess.Location = new Point(33, 67);
            txtProcess.Margin = new Padding(3, 4, 3, 4);
            txtProcess.Name = "txtProcess";
            txtProcess.Size = new Size(274, 38);
            txtProcess.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(355, 38);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 2;
            label2.Text = "Nhập số thành phần";
            // 
            // txtResource
            // 
            txtResource.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResource.Location = new Point(355, 67);
            txtResource.Margin = new Padding(3, 4, 3, 4);
            txtResource.Name = "txtResource";
            txtResource.Size = new Size(274, 38);
            txtResource.TabIndex = 3;
            // 
            // dgvInstance
            // 
            dgvInstance.AccessibleName = "";
            dgvInstance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInstance.Location = new Point(33, 155);
            dgvInstance.Margin = new Padding(3, 4, 3, 4);
            dgvInstance.Name = "dgvInstance";
            dgvInstance.RowHeadersWidth = 51;
            dgvInstance.Size = new Size(1033, 97);
            dgvInstance.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(33, 128);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 5;
            label3.Text = "Nhập Instance";
            // 
            // dgvAllocation
            // 
            dgvAllocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllocation.Location = new Point(33, 345);
            dgvAllocation.Margin = new Padding(3, 4, 3, 4);
            dgvAllocation.Name = "dgvAllocation";
            dgvAllocation.RowHeadersWidth = 51;
            dgvAllocation.Size = new Size(471, 269);
            dgvAllocation.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(33, 309);
            label4.Name = "label4";
            label4.Size = new Size(139, 23);
            label4.TabIndex = 7;
            label4.Text = "Nhập Allocation";
            // 
            // dgvMax
            // 
            dgvMax.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMax.Location = new Point(575, 345);
            dgvMax.Margin = new Padding(3, 4, 3, 4);
            dgvMax.Name = "dgvMax";
            dgvMax.RowHeadersWidth = 51;
            dgvMax.Size = new Size(491, 269);
            dgvMax.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(575, 309);
            label5.Name = "label5";
            label5.Size = new Size(92, 23);
            label5.TabIndex = 9;
            label5.Text = "Nhập Max";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(681, 67);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(160, 38);
            button1.TabIndex = 10;
            button1.Text = "Render";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(892, 642);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(174, 40);
            button2.TabIndex = 11;
            button2.Text = "Hoàn thành";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Deadlock_Input
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 707);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(dgvMax);
            Controls.Add(label4);
            Controls.Add(dgvAllocation);
            Controls.Add(label3);
            Controls.Add(dgvInstance);
            Controls.Add(txtResource);
            Controls.Add(label2);
            Controls.Add(txtProcess);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Deadlock_Input";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Deadlock_Input";
            ((System.ComponentModel.ISupportInitialize)dgvInstance).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProcess;
        private Label label2;
        private TextBox txtResource;
        private DataGridView dgvInstance;
        private Label label3;
        private DataGridView dgvAllocation;
        private Label label4;
        private DataGridView dgvMax;
        private Label label5;
        private Button button1;
        private Button button2;
    }
}