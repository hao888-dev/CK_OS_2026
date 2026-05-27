namespace CK_OS_2026
{
    partial class Deadlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deadlock));
            dgvMain = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            label9 = new Label();
            lblSafe = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Location = new Point(23, 98);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new Size(920, 227);
            dgvMain.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(188, 16);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Thiết lập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 71);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 2;
            label1.Text = "Bảng Hoàn Chỉnh";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(1, 0);
            label9.Name = "label9";
            label9.Size = new Size(148, 39);
            label9.TabIndex = 17;
            label9.Text = "Deadlock";
            // 
            // lblSafe
            // 
            lblSafe.AutoSize = true;
            lblSafe.Location = new Point(82, 370);
            lblSafe.Name = "lblSafe";
            lblSafe.Size = new Size(108, 15);
            lblSafe.TabIndex = 18;
            lblSafe.Text = "Chuỗi an toàn: null";
            // 
            // Deadlock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 530);
            Controls.Add(lblSafe);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dgvMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Deadlock";
            Text = "Deadlock";
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMain;
        private Button button1;
        private Label label1;
        private Label label9;
        private Label lblSafe;
    }
}