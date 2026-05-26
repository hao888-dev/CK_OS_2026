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
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            label1.Location = new Point(24, 27);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhập số Process";
            // 
            // txtProcess
            // 
            txtProcess.Location = new Point(29, 50);
            txtProcess.Name = "txtProcess";
            txtProcess.Size = new Size(100, 23);
            txtProcess.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 88);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 2;
            label2.Text = "Nhập số thành phần";
            // 
            // txtResource
            // 
            txtResource.Location = new Point(29, 117);
            txtResource.Name = "txtResource";
            txtResource.Size = new Size(100, 23);
            txtResource.TabIndex = 3;
            // 
            // dgvInstance
            // 
            dgvInstance.AccessibleName = "";
            dgvInstance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInstance.Location = new Point(29, 193);
            dgvInstance.Name = "dgvInstance";
            dgvInstance.Size = new Size(240, 202);
            dgvInstance.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 166);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "Nhập Instance";
            // 
            // dgvAllocation
            // 
            dgvAllocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllocation.Location = new Point(285, 193);
            dgvAllocation.Name = "dgvAllocation";
            dgvAllocation.Size = new Size(240, 202);
            dgvAllocation.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(285, 166);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 7;
            label4.Text = "Nhập Allocation";
            // 
            // dgvMax
            // 
            dgvMax.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMax.Location = new Point(548, 193);
            dgvMax.Name = "dgvMax";
            dgvMax.Size = new Size(240, 202);
            dgvMax.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(548, 166);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 9;
            label5.Text = "Nhập Max";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(167, 117);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Render";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(678, 415);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 11;
            button2.Text = "Hoàn thành";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Deadlock_Input
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Deadlock_Input";
            Text = "Deadlock_Input";
            ((System.ComponentModel.ISupportInitialize)dgvInstance).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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