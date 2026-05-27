namespace CK_OS_2026
{
    partial class SJF
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
            txtRowCount = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            dgvData = new System.Windows.Forms.DataGridView();
            colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colBurst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label2 = new System.Windows.Forms.Label();
            btnConfirm = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();   // "Kết quả"
            dgvResults = new System.Windows.Forms.DataGridView();
            resID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            resWT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            resRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            resTAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pnlGantt = new System.Windows.Forms.Panel();
            pictureBoxGantt = new System.Windows.Forms.PictureBox();
            lblAvgWT = new System.Windows.Forms.Label();
            lblAvgRT = new System.Windows.Forms.Label();
            lblAvgTAT = new System.Windows.Forms.Label();
            lblThroughput = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();   // "Giản đồ Gantt"
            groupBox1 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();   // "Thông năng"
            label7 = new System.Windows.Forms.Label();   // "Xoay vòng"
            label6 = new System.Windows.Forms.Label();   // "Đáp ứng"
            label5 = new System.Windows.Forms.Label();   // "Chờ"
            label9 = new System.Windows.Forms.Label();   // title header
            panel1 = new System.Windows.Forms.Panel();   // black accent Gantt
            panel2 = new System.Windows.Forms.Panel();   // black accent Kết quả
            label10 = new System.Windows.Forms.Label();   // "Nhập"
            panel3 = new System.Windows.Forms.Panel();   // black accent Nhập

            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            pnlGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();

            // ── txtRowCount ──────────────────────────────────────────────────
            txtRowCount.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtRowCount.Location = new System.Drawing.Point(38, 159);
            txtRowCount.Name = "txtRowCount";
            txtRowCount.PlaceholderText = "số phải >=0";
            txtRowCount.Size = new System.Drawing.Size(276, 31);
            txtRowCount.TabIndex = 0;

            // ── label1  "Nhập số lượng process" ─────────────────────────────
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(38, 131);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(202, 25);
            label1.TabIndex = 1;
            label1.Text = "Nhập số lượng process";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── btnCreate  "Xác nhận" ────────────────────────────────────────
            btnCreate.Location = new System.Drawing.Point(338, 159);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(136, 31);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Xác nhận";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            // ── dgvData ──────────────────────────────────────────────────────
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colID, colArrival, colBurst });
            dgvData.Location = new System.Drawing.Point(38, 252);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new System.Drawing.Size(436, 228);
            dgvData.TabIndex = 3;

            colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;

            colArrival.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colArrival.HeaderText = "Arrival Time";
            colArrival.MinimumWidth = 6;
            colArrival.Name = "colArrival";

            colBurst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colBurst.HeaderText = "Burst Time";
            colBurst.MinimumWidth = 6;
            colBurst.Name = "colBurst";

            // ── label2  "Nhập AT và BT …" ────────────────────────────────────
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(38, 224);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(376, 25);
            label2.TabIndex = 4;
            label2.Text = "Nhập AT và BT cho từng P (AT >= 0 , BT > 0)";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── btnConfirm  "Lập lịch" ───────────────────────────────────────
            btnConfirm.Location = new System.Drawing.Point(338, 498);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(136, 37);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Lập lịch";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;

            // ── label3  "Kết quả" ────────────────────────────────────────────
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Black", 19.8F,
                                   System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            label3.Location = new System.Drawing.Point(761, 92);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(147, 46);
            label3.TabIndex = 6;
            label3.Text = "Kết quả";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── dgvResults ───────────────────────────────────────────────────
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { resID, resWT, resRT, resTAT });
            dgvResults.Location = new System.Drawing.Point(573, 154);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new System.Drawing.Size(501, 188);
            dgvResults.TabIndex = 7;

            resID.HeaderText = "ID";
            resID.MinimumWidth = 6;
            resID.Name = "resID";
            resID.ReadOnly = true;

            resWT.HeaderText = "Waiting Time";
            resWT.MinimumWidth = 6;
            resWT.Name = "resWT";
            resWT.ReadOnly = true;

            resRT.HeaderText = "Response Time";
            resRT.MinimumWidth = 6;
            resRT.Name = "resRT";
            resRT.ReadOnly = true;

            resTAT.HeaderText = "Turnaround Time";
            resTAT.MinimumWidth = 6;
            resTAT.Name = "resTAT";
            resTAT.ReadOnly = true;

            // ── pnlGantt + pictureBoxGantt ───────────────────────────────────
            pnlGantt.AutoScroll = true;
            pnlGantt.Controls.Add(pictureBoxGantt);
            pnlGantt.Location = new System.Drawing.Point(-3, 591);
            pnlGantt.Name = "pnlGantt";
            pnlGantt.Size = new System.Drawing.Size(1110, 116);
            pnlGantt.TabIndex = 8;

            pictureBoxGantt.Location = new System.Drawing.Point(0, 0);
            pictureBoxGantt.Name = "pictureBoxGantt";
            pictureBoxGantt.Size = new System.Drawing.Size(125, 62);
            pictureBoxGantt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBoxGantt.TabIndex = 0;
            pictureBoxGantt.TabStop = false;

            // ── lblAvgWT / RT / TAT / Throughput ─────────────────────────────
            lblAvgWT.AutoSize = true;
            lblAvgWT.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblAvgWT.Location = new System.Drawing.Point(420, 44);
            lblAvgWT.Name = "lblAvgWT";
            lblAvgWT.TabIndex = 9;
            lblAvgWT.Text = "0";

            lblAvgRT.AutoSize = true;
            lblAvgRT.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblAvgRT.Location = new System.Drawing.Point(420, 79);
            lblAvgRT.Name = "lblAvgRT";
            lblAvgRT.TabIndex = 10;
            lblAvgRT.Text = "0";

            lblAvgTAT.AutoSize = true;
            lblAvgTAT.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblAvgTAT.Location = new System.Drawing.Point(420, 113);
            lblAvgTAT.Name = "lblAvgTAT";
            lblAvgTAT.TabIndex = 11;
            lblAvgTAT.Text = "0";

            lblThroughput.AutoSize = true;
            lblThroughput.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblThroughput.Location = new System.Drawing.Point(420, 147);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.TabIndex = 12;
            lblThroughput.Text = "0";

            // ── label4  "Giản đồ Gantt" ──────────────────────────────────────
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Black", 19.8F,
                                   System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            label4.Location = new System.Drawing.Point(38, 542);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(261, 46);
            label4.TabIndex = 13;
            label4.Text = "Giản đồ  Gantt";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── groupBox1  "Giá trị tính được" ──────────────────────────────
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblAvgRT);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblAvgWT);
            groupBox1.Controls.Add(lblThroughput);
            groupBox1.Controls.Add(lblAvgTAT);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F,
                                     System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            groupBox1.Location = new System.Drawing.Point(573, 376);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(501, 187);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá trị tính được";

            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(22, 44);
            label5.Name = "label5";
            label5.TabIndex = 13;
            label5.Text = "Thời gian chờ trung bình (WT):";

            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(22, 79);
            label6.Name = "label6";
            label6.TabIndex = 14;
            label6.Text = "Thời gian đáp ứng trung bình (RT):";

            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(22, 113);
            label7.Name = "label7";
            label7.TabIndex = 15;
            label7.Text = "Thời gian xoay vòng trung bình:";

            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(22, 147);
            label8.Name = "label8";
            label8.TabIndex = 16;
            label8.Text = "Thông năng:";

            // ── label9  header title "Shortest Job First" ────────────────────
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label9.Font = new System.Drawing.Font("Sitka Small", 19.8F, System.Drawing.FontStyle.Bold);
            label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            label9.Location = new System.Drawing.Point(288, -3);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(584, 50);
            label9.TabIndex = 15;
            label9.Text = "Shortest Job First";

            // ── panel1  black accent (cạnh Giản đồ Gantt) ───────────────────
            panel1.BackColor = System.Drawing.Color.Black;
            panel1.Location = new System.Drawing.Point(0, 546);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(56, 42);
            panel1.TabIndex = 16;

            // ── panel2  black accent (cạnh Kết quả) ─────────────────────────
            panel2.BackColor = System.Drawing.Color.Black;
            panel2.Location = new System.Drawing.Point(914, 96);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(193, 42);
            panel2.TabIndex = 17;

            // ── label10  "Nhập" ──────────────────────────────────────────────
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Black", 19.8F,
                                    System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            label10.Location = new System.Drawing.Point(363, 73);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(111, 46);
            label10.TabIndex = 18;
            label10.Text = "Nhập";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── panel3  black accent (cạnh Nhập) ────────────────────────────
            panel3.BackColor = System.Drawing.Color.Black;
            panel3.Location = new System.Drawing.Point(0, 77);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(372, 42);
            panel3.TabIndex = 18;

            // ── FORM ─────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1106, 707);
            Text = "SJF";
            Name = "SJFForm";

            Controls.Add(label10);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label9);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(pnlGantt);
            Controls.Add(dgvResults);
            Controls.Add(label3);
            Controls.Add(btnConfirm);
            Controls.Add(label2);
            Controls.Add(dgvData);
            Controls.Add(btnCreate);
            Controls.Add(label1);
            Controls.Add(txtRowCount);
            Controls.Add(panel1);

            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            pnlGantt.ResumeLayout(false);
            pnlGantt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBurst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn resID;
        private System.Windows.Forms.DataGridViewTextBoxColumn resWT;
        private System.Windows.Forms.DataGridViewTextBoxColumn resRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn resTAT;
        private System.Windows.Forms.Panel pnlGantt;
        private System.Windows.Forms.PictureBox pictureBoxGantt;
        private System.Windows.Forms.Label lblAvgWT;
        private System.Windows.Forms.Label lblAvgRT;
        private System.Windows.Forms.Label lblAvgTAT;
        private System.Windows.Forms.Label lblThroughput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
    }
}