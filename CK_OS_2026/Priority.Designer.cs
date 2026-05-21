namespace CK_OS_2026
{
    partial class Priority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Priority));
            dgvInput = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colAT = new DataGridViewTextBoxColumn();
            colBT = new DataGridViewTextBoxColumn();
            colPri = new DataGridViewTextBoxColumn();
            txtSoLuong = new TextBox();
            btnNhap = new Button();
            btnThucHien = new Button();
            label9 = new Label();
            label1 = new Label();
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
            label10 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            groupBox1.SuspendLayout();
            pnlGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGantt).BeginInit();
            SuspendLayout();
            // 
            // dgvInput
            // 
            dgvInput.AllowUserToAddRows = false;
            dgvInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInput.Columns.AddRange(new DataGridViewColumn[] { colID, colAT, colBT, colPri });
            dgvInput.Location = new Point(37, 249);
            dgvInput.Name = "dgvInput";
            dgvInput.RowHeadersWidth = 51;
            dgvInput.Size = new Size(459, 236);
            dgvInput.TabIndex = 0;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.Width = 53;
            // 
            // colAT
            // 
            colAT.HeaderText = "Arrival Time";
            colAT.MinimumWidth = 6;
            colAT.Name = "colAT";
            // 
            // colBT
            // 
            colBT.HeaderText = "Burst Time";
            colBT.MinimumWidth = 6;
            colBT.Name = "colBT";
            // 
            // colPri
            // 
            colPri.HeaderText = "Priority";
            colPri.MinimumWidth = 6;
            colPri.Name = "colPri";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.Location = new Point(37, 163);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.PlaceholderText = ">= 0";
            txtSoLuong.Size = new Size(342, 34);
            txtSoLuong.TabIndex = 1;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(402, 163);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 34);
            btnNhap.TabIndex = 2;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            // 
            // btnThucHien
            // 
            btnThucHien.Location = new Point(393, 504);
            btnThucHien.Name = "btnThucHien";
            btnThucHien.Size = new Size(103, 42);
            btnThucHien.TabIndex = 4;
            btnThucHien.Text = "Thực hiện";
            btnThucHien.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(-1, -6);
            label9.Name = "label9";
            label9.Size = new Size(165, 49);
            label9.TabIndex = 16;
            label9.Text = "Priority";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 130);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 17;
            label1.Text = "Nhập số lượng process";
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { resID, resWT, resRT, resTAT });
            dgvResults.Location = new Point(595, 87);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(455, 254);
            dgvResults.TabIndex = 18;
            // 
            // resID
            // 
            resID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            resID.HeaderText = "ID";
            resID.MinimumWidth = 6;
            resID.Name = "resID";
            resID.ReadOnly = true;
            resID.Width = 53;
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
            groupBox1.Location = new Point(595, 364);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 187);
            groupBox1.TabIndex = 19;
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
            // lblAvgRT
            // 
            lblAvgRT.AutoSize = true;
            lblAvgRT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgRT.Location = new Point(394, 79);
            lblAvgRT.Name = "lblAvgRT";
            lblAvgRT.Size = new Size(22, 25);
            lblAvgRT.TabIndex = 10;
            lblAvgRT.Text = "0";
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
            // lblAvgWT
            // 
            lblAvgWT.AutoSize = true;
            lblAvgWT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgWT.Location = new Point(394, 44);
            lblAvgWT.Name = "lblAvgWT";
            lblAvgWT.Size = new Size(22, 25);
            lblAvgWT.TabIndex = 9;
            lblAvgWT.Text = "0";
            // 
            // lblThroughput
            // 
            lblThroughput.AutoSize = true;
            lblThroughput.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblThroughput.Location = new Point(394, 147);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(22, 25);
            lblThroughput.TabIndex = 12;
            lblThroughput.Text = "0";
            // 
            // lblAvgTAT
            // 
            lblAvgTAT.AutoSize = true;
            lblAvgTAT.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblAvgTAT.Location = new Point(394, 113);
            lblAvgTAT.Name = "lblAvgTAT";
            lblAvgTAT.Size = new Size(22, 25);
            lblAvgTAT.TabIndex = 11;
            lblAvgTAT.Text = "0";
            // 
            // pnlGantt
            // 
            pnlGantt.Controls.Add(pictureBoxGantt);
            pnlGantt.Location = new Point(-1, 597);
            pnlGantt.Name = "pnlGantt";
            pnlGantt.Size = new Size(1110, 116);
            pnlGantt.TabIndex = 20;
            // 
            // pictureBoxGantt
            // 
            pictureBoxGantt.Location = new Point(0, 0);
            pictureBoxGantt.Name = "pictureBoxGantt";
            pictureBoxGantt.Size = new Size(125, 62);
            pictureBoxGantt.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGantt.TabIndex = 28;
            pictureBoxGantt.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(385, 70);
            label10.Name = "label10";
            label10.Size = new Size(111, 46);
            label10.TabIndex = 21;
            label10.Text = "Nhập";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(-2, 74);
            panel3.Name = "panel3";
            panel3.Size = new Size(381, 42);
            panel3.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(916, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(193, 42);
            panel2.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(763, 20);
            label3.Name = "label3";
            label3.Size = new Size(147, 46);
            label3.TabIndex = 23;
            label3.Text = "Kết quả";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 545);
            label4.Name = "label4";
            label4.Size = new Size(261, 46);
            label4.TabIndex = 25;
            label4.Text = "Giản đồ  Gantt";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(-1, 549);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 42);
            panel1.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(37, 221);
            label2.Name = "label2";
            label2.Size = new Size(436, 25);
            label2.TabIndex = 27;
            label2.Text = "Nhập dữ liệu cho từng P (AT >= 0 , BT > 0, Priority)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Non-Preemptive", "Preemptive" });
            comboBox1.Location = new Point(37, 512);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(280, 28);
            comboBox1.TabIndex = 28;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Priority
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1106, 707);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(label10);
            Controls.Add(pnlGantt);
            Controls.Add(groupBox1);
            Controls.Add(dgvResults);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(btnThucHien);
            Controls.Add(btnNhap);
            Controls.Add(txtSoLuong);
            Controls.Add(dgvInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Priority";
            Text = "Priority";
            ((System.ComponentModel.ISupportInitialize)dgvInput).EndInit();
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

        private DataGridView dgvInput;
        private TextBox txtSoLuong;
        private Button btnNhap;
        private Button btnThucHien;
        private Label label9;
        private Label label1;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colAT;
        private DataGridViewTextBoxColumn colBT;
        private DataGridViewTextBoxColumn colPri;
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
        private Label label10;
        private Panel panel3;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBoxGantt;
        private ComboBox comboBox1;
    }
}