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
            labelTitle = new System.Windows.Forms.Label();
            panelTitleLeft = new System.Windows.Forms.Panel();
            panelTitleRight = new System.Windows.Forms.Panel();

            labelNhap = new System.Windows.Forms.Label();
            panelNhapLeft = new System.Windows.Forms.Panel();
            panelNhapRight = new System.Windows.Forms.Panel();

            labelXuat = new System.Windows.Forms.Label();
            panelXuatLeft = new System.Windows.Forms.Panel();
            panelXuatRight = new System.Windows.Forms.Panel();

            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();

            label3 = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            colPageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPageVal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            label2 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();

            button2 = new System.Windows.Forms.Button();


            dataGridView2 = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();

            // ── labelTitle  "FIFO" ─────────────────────────────────────────
            // Căn giữa: form width=1106, label width~95 → x=(1106-95)/2≈505
            labelTitle.AutoSize = false;
            labelTitle.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelTitle.Font = new System.Drawing.Font("Sitka Small", 19.8F, System.Drawing.FontStyle.Bold);
            labelTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            labelTitle.Location = new System.Drawing.Point(450, -3);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(206, 50);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "FIFO";
            labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── panelTitleLeft / Right (black bars kẹp tiêu đề) ────────────
            panelTitleLeft.BackColor = System.Drawing.Color.Black;
            panelTitleLeft.Location = new System.Drawing.Point(1, 5);
            panelTitleLeft.Name = "panelTitleLeft";
            panelTitleLeft.Size = new System.Drawing.Size(443, 40);
            panelTitleLeft.TabIndex = 1;

            panelTitleRight.BackColor = System.Drawing.Color.Black;
            panelTitleRight.Location = new System.Drawing.Point(662, 5);
            panelTitleRight.Name = "panelTitleRight";
            panelTitleRight.Size = new System.Drawing.Size(443, 40);
            panelTitleRight.TabIndex = 2;

            // ── labelNhap  "Nhập" ─────────────────────────────────────────
            // Căn giữa form: x=(1106-111)/2≈497
            labelNhap.AutoSize = true;
            labelNhap.Font = new System.Drawing.Font("Segoe UI Black", 19.8F,
                                       System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            labelNhap.Location = new System.Drawing.Point(497, 67);
            labelNhap.Name = "labelNhap";
            labelNhap.Size = new System.Drawing.Size(111, 46);
            labelNhap.TabIndex = 3;
            labelNhap.Text = "Nhập";
            labelNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── panelNhapLeft / Right (black bars kẹp "Nhập") ──────────────
            panelNhapLeft.BackColor = System.Drawing.Color.Black;
            panelNhapLeft.Location = new System.Drawing.Point(1, 99);
            panelNhapLeft.Name = "panelNhapLeft";
            panelNhapLeft.Size = new System.Drawing.Size(490, 14);
            panelNhapLeft.TabIndex = 4;

            panelNhapRight.BackColor = System.Drawing.Color.Black;
            panelNhapRight.Location = new System.Drawing.Point(614, 99);
            panelNhapRight.Name = "panelNhapRight";
            panelNhapRight.Size = new System.Drawing.Size(491, 14);
            panelNhapRight.TabIndex = 5;

            // ── label1  "Số trang" ────────────────────────────────────────
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            label1.Location = new System.Drawing.Point(25, 145);
            label1.Name = "label1";
            label1.TabIndex = 6;
            label1.Text = "Số trang";

            // ── textBox1 ──────────────────────────────────────────────────
            textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            textBox1.Location = new System.Drawing.Point(25, 173);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "> 0";
            textBox1.Size = new System.Drawing.Size(225, 34);
            textBox1.TabIndex = 7;

            // ── button1  "Nhập" ───────────────────────────────────────────
            button1.Location = new System.Drawing.Point(25, 225);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(99, 34);
            button1.TabIndex = 8;
            button1.Text = "Nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // ── label3  "Nhập chuỗi tham chiếu trang nhớ" ────────────────
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(280, 145);
            label3.Name = "label3";
            label3.TabIndex = 9;
            label3.Text = "Nhập chuỗi tham chiếu trang nhớ";

            // ── dataGridView1 (chuỗi tham chiếu) ─────────────────────────
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPageName, colPageVal });
            dataGridView1.Location = new System.Drawing.Point(280, 173);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(347, 175);
            dataGridView1.TabIndex = 10;

            colPageName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPageName.HeaderText = "Trang";
            colPageName.MinimumWidth = 6;
            colPageName.Name = "colPageName";
            colPageName.ReadOnly = true;

            colPageVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPageVal.HeaderText = "Giá trị";
            colPageVal.MinimumWidth = 6;
            colPageVal.Name = "colPageVal";

            // ── label2  "Số frame được cung cấp" ─────────────────────────
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            label2.Location = new System.Drawing.Point(661, 145);
            label2.Name = "label2";
            label2.TabIndex = 11;
            label2.Text = "Số frame được cung cấp";

            // ── textBox2 ──────────────────────────────────────────────────
            textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            textBox2.Location = new System.Drawing.Point(661, 173);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "> 0";
            textBox2.Size = new System.Drawing.Size(405, 34);
            textBox2.TabIndex = 12;

            // ── button2  "Thực hiện" ──────────────────────────────────────
            button2.Location = new System.Drawing.Point(898, 314);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(168, 34);
            button2.TabIndex = 13;
            button2.Text = "Thực hiện";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // ── labelXuat  "Xuất" ─────────────────────────────────────────
            // Căn giữa: x=(1106-100)/2≈503
            labelXuat.AutoSize = true;
            labelXuat.Font = new System.Drawing.Font("Segoe UI Black", 19.8F,
                                       System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            labelXuat.Location = new System.Drawing.Point(503, 370);
            labelXuat.Name = "labelXuat";
            labelXuat.Size = new System.Drawing.Size(100, 46);
            labelXuat.TabIndex = 16;
            labelXuat.Text = "Xuất";
            labelXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── panelXuatLeft / Right (black bars kẹp "Xuất") ─────────────
            panelXuatLeft.BackColor = System.Drawing.Color.Black;
            panelXuatLeft.Location = new System.Drawing.Point(1, 402);
            panelXuatLeft.Name = "panelXuatLeft";
            panelXuatLeft.Size = new System.Drawing.Size(496, 14);
            panelXuatLeft.TabIndex = 17;

            panelXuatRight.BackColor = System.Drawing.Color.Black;
            panelXuatRight.Location = new System.Drawing.Point(608, 402);
            panelXuatRight.Name = "panelXuatRight";
            panelXuatRight.Size = new System.Drawing.Size(497, 14);
            panelXuatRight.TabIndex = 18;

            // ── dataGridView2 (kết quả) ───────────────────────────────────
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new System.Drawing.Point(25, 458);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new System.Drawing.Size(1049, 208);
            dataGridView2.TabIndex = 19;

            // ── FORM ──────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1106, 707);
            Text = "FIFO Page Replacement";
            Name = "FIFOPageReplacement";

            Controls.Add(panelTitleLeft);
            Controls.Add(panelTitleRight);
            Controls.Add(labelTitle);
            Controls.Add(labelNhap);
            Controls.Add(panelNhapLeft);
            Controls.Add(panelNhapRight);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(labelXuat);
            Controls.Add(panelXuatLeft);
            Controls.Add(panelXuatRight);
            Controls.Add(dataGridView2);

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelTitleLeft;
        private System.Windows.Forms.Panel panelTitleRight;
        private System.Windows.Forms.Label labelNhap;
        private System.Windows.Forms.Panel panelNhapLeft;
        private System.Windows.Forms.Panel panelNhapRight;
        private System.Windows.Forms.Label labelXuat;
        private System.Windows.Forms.Panel panelXuatLeft;
        private System.Windows.Forms.Panel panelXuatRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPageVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}