namespace CK_OS_2026
{
    partial class FIFO
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIFO));
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtFramesCount = new TextBox();
            txtPages = new TextBox();
            runCode = new Button();
            dgvResults = new DataGridView();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 298);
            label3.Name = "label3";
            label3.Size = new Size(149, 41);
            label3.TabIndex = 29;
            label3.Text = "Kết quả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 130);
            label2.Name = "label2";
            label2.Size = new Size(206, 31);
            label2.TabIndex = 28;
            label2.Text = "Số frame được cấp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 37);
            label1.Name = "label1";
            label1.Size = new Size(298, 31);
            label1.TabIndex = 27;
            label1.Text = "Nhập chuỗi tham chiếu nhớ";
            // 
            // txtFramesCount
            // 
            txtFramesCount.Font = new Font("Segoe UI", 16.2F);
            txtFramesCount.Location = new Point(35, 164);
            txtFramesCount.Name = "txtFramesCount";
            txtFramesCount.Size = new Size(1016, 43);
            txtFramesCount.TabIndex = 26;
            // 
            // txtPages
            // 
            txtPages.Font = new Font("Segoe UI", 16.2F);
            txtPages.Location = new Point(35, 71);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(1016, 43);
            txtPages.TabIndex = 25;
            // 
            // runCode
            // 
            runCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            runCode.Location = new Point(857, 226);
            runCode.Name = "runCode";
            runCode.Size = new Size(194, 49);
            runCode.TabIndex = 24;
            runCode.Text = "Chạy";
            runCode.UseVisualStyleBackColor = true;
            runCode.Click += runCode_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(35, 342);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(1016, 311);
            dgvResults.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(999, 0);
            label9.Name = "label9";
            label9.Size = new Size(109, 50);
            label9.TabIndex = 30;
            label9.Text = "FIFO";
            // 
            // FIFO
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 707);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFramesCount);
            Controls.Add(txtPages);
            Controls.Add(runCode);
            Controls.Add(dgvResults);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FIFO";
            Text = "FIFO";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtFramesCount;
        private TextBox txtPages;
        private Button runCode;
        private DataGridView dgvResults;
        private Label label9;
    }
}