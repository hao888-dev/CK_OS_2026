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
            txtRowCount = new TextBox();
            label1 = new Label();
            btnCreate = new Button();
            dgvData = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colArrival = new DataGridViewTextBoxColumn();
            colBurst = new DataGridViewTextBoxColumn();
            label2 = new Label();
            btnConfirm = new Button();
            label3 = new Label();
            dgvResults = new DataGridView();
            resID = new DataGridViewTextBoxColumn();
            resWT = new DataGridViewTextBoxColumn();
            resRT = new DataGridViewTextBoxColumn();
            resTAT = new DataGridViewTextBoxColumn();
            pnlGantt = new Panel();
            pictureBoxGantt = new PictureBox();
            lblAvgWT = new Label();
            lblAvgRT = new Label();
            lblAvgTAT = new Label();
            lblThroughput = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label10 = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            pnlGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRowCount
            // 
            txtRowCount.Font = new Font("Segoe UI", 10.8F);
            txtRowCount.Location = new Point(38, 159);
            txtRowCount.Name = "txtRowCount";
            txtRowCount.PlaceholderText = "số phải >=0";
            txtRowCount.Size = new Size(276, 31);
            txtRowCount.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(38, 131);
            label1.Name = "label1";
            label1.Size = new Size(202, 25);
            label1.TabIndex = 1;
            label1.Text = "Nhập số lượng process";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(338, 159);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(136, 31);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Xác nhận";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colID, colArrival, colBurst });
            dgvData.Location = new Point(38, 252);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(436, 228);
            dgvData.TabIndex = 3;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colArrival
            // 
            colArrival.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colArrival.HeaderText = "Arrival Time";
            colArrival.MinimumWidth = 6;
            colArrival.Name = "colArrival";
            // 
            // colBurst
            // 
            colBurst.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBurst.HeaderText = "Burst Time";
            colBurst.MinimumWidth = 6;
            colBurst.Name = "colBurst";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(38, 224);
            label2.Name = "label2";
            label2.Size = new Size(376, 25);
            label2.TabIndex = 4;
            label2.Text = "Nhập AT và BT cho từng P (AT >= 0 , BT > 0)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(338, 498);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(136, 37);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Lập lịch";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 19.8F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(761, 92);
            label3.Name = "label3";
            label3.Size = new Size(147, 45);
            label3.TabIndex = 6;
            label3.Text = "Kết quả";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { resID, resWT, resRT, resTAT });
            dgvResults.Location = new Point(573, 154);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(501, 188);
            dgvResults.TabIndex = 7;
            // 
            // resID
            // 
            resID.HeaderText = "ID";
            resID.MinimumWidth = 6;
            resID.Name = "resID";
            resID.ReadOnly = true;
            // 
            // resWT
            // 
            resWT.HeaderText = "Waiting Time";
            resWT.MinimumWidth = 6;
            resWT.Name = "resWT";
            resWT.ReadOnly = true;
            // 
            // resRT
            // 
            resRT.HeaderText = "Response Time";
            resRT.MinimumWidth = 6;
            resRT.Name = "resRT";
            resRT.ReadOnly = true;
            // 
            // resTAT
            // 
            resTAT.HeaderText = "Turnaround Time";
            resTAT.MinimumWidth = 6;
            resTAT.Name = "resTAT";
            resTAT.ReadOnly = true;
            // 
            // pnlGantt
            // 
            pnlGantt.AutoScroll = true;
            pnlGantt.Controls.Add(pictureBoxGantt);
            pnlGantt.Location = new Point(-3, 591);
            pnlGantt.Name = "pnlGantt";
            pnlGantt.Size = new Size(1110, 116);
            pnlGantt.TabIndex = 8;
            // 
            // pictureBoxGantt
            // 
            pictureBoxGantt.Location = new Point(0, 0);
            pictureBoxGantt.Name = "pictureBoxGantt";
            pictureBoxGantt.Size = new Size(125, 62);
            pictureBoxGantt.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGantt.TabIndex = 0;
            pictureBoxGantt.TabStop = false;
            // 
            // lblAvgWT
            // 
            lblAvgWT.AutoSize = true;
            lblAvgWT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgWT.Location = new Point(420, 44);
            lblAvgWT.Name = "lblAvgWT";
            lblAvgWT.Size = new Size(22, 25);
            lblAvgWT.TabIndex = 9;
            lblAvgWT.Text = "0";
            // 
            // lblAvgRT
            // 
            lblAvgRT.AutoSize = true;
            lblAvgRT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgRT.Location = new Point(420, 79);
            lblAvgRT.Name = "lblAvgRT";
            lblAvgRT.Size = new Size(22, 25);
            lblAvgRT.TabIndex = 10;
            lblAvgRT.Text = "0";
            // 
            // lblAvgTAT
            // 
            lblAvgTAT.AutoSize = true;
            lblAvgTAT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgTAT.Location = new Point(420, 113);
            lblAvgTAT.Name = "lblAvgTAT";
            lblAvgTAT.Size = new Size(22, 25);
            lblAvgTAT.TabIndex = 11;
            lblAvgTAT.Text = "0";
            // 
            // lblThroughput
            // 
            lblThroughput.AutoSize = true;
            lblThroughput.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblThroughput.Location = new Point(420, 147);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(22, 25);
            lblThroughput.TabIndex = 12;
            lblThroughput.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 19.8F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(38, 543);
            label4.Name = "label4";
            label4.Size = new Size(258, 45);
            label4.TabIndex = 13;
            label4.Text = "Giản đồ  Gantt";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblAvgRT);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblAvgWT);
            groupBox1.Controls.Add(lblThroughput);
            groupBox1.Controls.Add(lblAvgTAT);
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.Location = new Point(573, 376);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(501, 187);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá trị tính được";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label8.Location = new Point(22, 147);
            label8.Name = "label8";
            label8.Size = new Size(116, 25);
            label8.TabIndex = 16;
            label8.Text = "Thông năng:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label7.Location = new Point(22, 113);
            label7.Name = "label7";
            label7.Size = new Size(277, 25);
            label7.TabIndex = 15;
            label7.Text = "Thời gian xoay vòng trung bình:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label6.Location = new Point(22, 79);
            label6.Name = "label6";
            label6.Size = new Size(299, 25);
            label6.TabIndex = 14;
            label6.Text = "Thời gian đáp ứng trung bình (RT):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label5.Location = new Point(22, 44);
            label5.Name = "label5";
            label5.Size = new Size(265, 25);
            label5.TabIndex = 13;
            label5.Text = "Thời gian chờ trung bình (WT):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(0, -3);
            label9.Name = "label9";
            label9.Size = new Size(332, 49);
            label9.TabIndex = 15;
            label9.Text = "Shortest Job First";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(0, 546);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 42);
            panel1.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(914, 96);
            panel2.Name = "panel2";
            panel2.Size = new Size(193, 42);
            panel2.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 19.8F, FontStyle.Bold | FontStyle.Italic);
            label10.Location = new Point(364, 74);
            label10.Name = "label10";
            label10.Size = new Size(110, 45);
            label10.TabIndex = 18;
            label10.Text = "Nhập";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(0, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(372, 42);
            panel3.TabIndex = 18;
            // 
            // SJF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1106, 707);
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
            Name = "SJF";
            Text = "SJF";
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