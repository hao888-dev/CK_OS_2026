namespace CK_OS_2026
{
    partial class FCFS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCFS));
            panel3 = new Panel();
            label9 = new Label();
            label10 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label1 = new Label();
            txtRowCount = new TextBox();
            btnCreate = new Button();
            label2 = new Label();
            dgvData = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colArrival = new DataGridViewTextBoxColumn();
            colBurst = new DataGridViewTextBoxColumn();
            dgvResults = new DataGridView();
            resID = new DataGridViewTextBoxColumn();
            resWT = new DataGridViewTextBoxColumn();
            resRT = new DataGridViewTextBoxColumn();
            resTAT = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            lblAvgRT = new Label();
            label5 = new Label();
            lblAvgWT = new Label();
            lblThroughput = new Label();
            lblAvgTAT = new Label();
            pnlGantt = new Panel();
            pictureBoxGantt = new PictureBox();
            btnConfirm = new Button();
            panel1 = new Panel();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            groupBox1.SuspendLayout();
            pnlGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(1, 54);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(326, 32);
            panel3.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(319, -2);
            label9.Name = "label9";
            label9.Size = new Size(339, 39);
            label9.TabIndex = 20;
            label9.Text = "First Come First Serve";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(333, 54);
            label10.Name = "label10";
            label10.Size = new Size(90, 37);
            label10.TabIndex = 21;
            label10.Text = "Nhập";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(800, 87);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 32);
            panel2.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(674, 87);
            label3.Name = "label3";
            label3.Size = new Size(120, 37);
            label3.TabIndex = 23;
            label3.Text = "Kết quả";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(12, 99);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 24;
            label1.Text = "Nhập số lượng process";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRowCount
            // 
            txtRowCount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRowCount.Location = new Point(12, 121);
            txtRowCount.Margin = new Padding(3, 2, 3, 2);
            txtRowCount.Name = "txtRowCount";
            txtRowCount.PlaceholderText = "số phải >=0";
            txtRowCount.Size = new Size(242, 27);
            txtRowCount.TabIndex = 25;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(265, 125);
            btnCreate.Margin = new Padding(3, 2, 3, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(119, 23);
            btnCreate.TabIndex = 26;
            btnCreate.Text = "Xác nhận";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(12, 162);
            label2.Name = "label2";
            label2.Size = new Size(307, 20);
            label2.TabIndex = 27;
            label2.Text = "Nhập AT và BT cho từng P (AT >= 0 , BT > 0)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colID, colArrival, colBurst });
            dgvData.Location = new Point(12, 193);
            dgvData.Margin = new Padding(3, 2, 3, 2);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(382, 171);
            dgvData.TabIndex = 28;
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
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { resID, resWT, resRT, resTAT });
            dgvResults.Location = new Point(518, 126);
            dgvResults.Margin = new Padding(3, 2, 3, 2);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(438, 141);
            dgvResults.TabIndex = 29;
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
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(518, 288);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(438, 140);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá trị tính được";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label8.Location = new Point(19, 109);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 16;
            label8.Text = "Thông năng:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label7.Location = new Point(19, 84);
            label7.Name = "label7";
            label7.Size = new Size(230, 20);
            label7.TabIndex = 15;
            label7.Text = "Thời gian xoay vòng trung bình:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label6.Location = new Point(19, 58);
            label6.Name = "label6";
            label6.Size = new Size(246, 20);
            label6.TabIndex = 14;
            label6.Text = "Thời gian đáp ứng trung bình (RT):";
            // 
            // lblAvgRT
            // 
            lblAvgRT.AutoSize = true;
            lblAvgRT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgRT.Location = new Point(368, 58);
            lblAvgRT.Name = "lblAvgRT";
            lblAvgRT.Size = new Size(17, 20);
            lblAvgRT.TabIndex = 10;
            lblAvgRT.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label5.Location = new Point(19, 32);
            label5.Name = "label5";
            label5.Size = new Size(219, 20);
            label5.TabIndex = 13;
            label5.Text = "Thời gian chờ trung bình (WT):";
            // 
            // lblAvgWT
            // 
            lblAvgWT.AutoSize = true;
            lblAvgWT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgWT.Location = new Point(368, 32);
            lblAvgWT.Name = "lblAvgWT";
            lblAvgWT.Size = new Size(17, 20);
            lblAvgWT.TabIndex = 9;
            lblAvgWT.Text = "0";
            // 
            // lblThroughput
            // 
            lblThroughput.AutoSize = true;
            lblThroughput.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblThroughput.Location = new Point(368, 109);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(17, 20);
            lblThroughput.TabIndex = 12;
            lblThroughput.Text = "0";
            // 
            // lblAvgTAT
            // 
            lblAvgTAT.AutoSize = true;
            lblAvgTAT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgTAT.Location = new Point(368, 84);
            lblAvgTAT.Name = "lblAvgTAT";
            lblAvgTAT.Size = new Size(17, 20);
            lblAvgTAT.TabIndex = 11;
            lblAvgTAT.Text = "0";
            // 
            // pnlGantt
            // 
            pnlGantt.AutoScroll = true;
            pnlGantt.Controls.Add(pictureBoxGantt);
            pnlGantt.Location = new Point(1, 443);
            pnlGantt.Margin = new Padding(3, 2, 3, 2);
            pnlGantt.Name = "pnlGantt";
            pnlGantt.Size = new Size(971, 87);
            pnlGantt.TabIndex = 31;
            // 
            // pictureBoxGantt
            // 
            pictureBoxGantt.Location = new Point(0, 0);
            pictureBoxGantt.Margin = new Padding(3, 2, 3, 2);
            pictureBoxGantt.Name = "pictureBoxGantt";
            pictureBoxGantt.Size = new Size(125, 62);
            pictureBoxGantt.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGantt.TabIndex = 0;
            pictureBoxGantt.TabStop = false;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(275, 372);
            btnConfirm.Margin = new Padding(3, 2, 3, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(119, 28);
            btnConfirm.TabIndex = 32;
            btnConfirm.Text = "Lập lịch";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(1, 407);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(49, 32);
            panel1.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 402);
            label4.Name = "label4";
            label4.Size = new Size(209, 37);
            label4.TabIndex = 34;
            label4.Text = "Giản đồ  Gantt";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FCFS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 530);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(btnConfirm);
            Controls.Add(pnlGantt);
            Controls.Add(groupBox1);
            Controls.Add(dgvResults);
            Controls.Add(dgvData);
            Controls.Add(label2);
            Controls.Add(btnCreate);
            Controls.Add(txtRowCount);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(panel3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FCFS";
            Text = "FCFS";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlGantt.ResumeLayout(false);
            pnlGantt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label label9;
        private Label label10;
        private Panel panel2;
        private Label label3;
        private Label label1;
        private TextBox txtRowCount;
        private Button btnCreate;
        private Label label2;
        private DataGridView dgvData;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colArrival;
        private DataGridViewTextBoxColumn colBurst;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn resID;
        private DataGridViewTextBoxColumn resWT;
        private DataGridViewTextBoxColumn resRT;
        private DataGridViewTextBoxColumn resTAT;
        private GroupBox groupBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label lblAvgRT;
        private Label label5;
        private Label lblAvgWT;
        private Label lblThroughput;
        private Label lblAvgTAT;
        private Panel pnlGantt;
        private PictureBox pictureBoxGantt;
        private Button btnConfirm;
        private Panel panel1;
        private Label label4;
    }
}