namespace CK_OS_2026
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            BtnOPT = new Button();
            BtnDeadlock = new Button();
            BtnPriority = new Button();
            BtnRR = new Button();
            BtnSRTF = new Button();
            BtnSJF = new Button();
            BtnFCFS = new Button();
            BtnHome = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(BtnOPT);
            panel1.Controls.Add(BtnDeadlock);
            panel1.Controls.Add(BtnPriority);
            panel1.Controls.Add(BtnRR);
            panel1.Controls.Add(BtnSRTF);
            panel1.Controls.Add(BtnSJF);
            panel1.Controls.Add(BtnFCFS);
            panel1.Controls.Add(BtnHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(202, 708);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_glasses_100;
            pictureBox1.Location = new Point(21, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // BtnOPT
            // 
            BtnOPT.BackColor = Color.FromArgb(64, 64, 64);
            BtnOPT.FlatAppearance.BorderColor = Color.White;
            BtnOPT.FlatAppearance.BorderSize = 0;
            BtnOPT.FlatStyle = FlatStyle.Flat;
            BtnOPT.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOPT.ForeColor = Color.White;
            BtnOPT.Location = new Point(-5, 594);
            BtnOPT.Name = "BtnOPT";
            BtnOPT.Size = new Size(207, 70);
            BtnOPT.TabIndex = 8;
            BtnOPT.Text = "OPT";
            BtnOPT.UseVisualStyleBackColor = false;
            BtnOPT.Click += BtnOPT_Click;
            // 
            // BtnDeadlock
            // 
            BtnDeadlock.BackColor = Color.FromArgb(64, 64, 64);
            BtnDeadlock.FlatAppearance.BorderColor = Color.White;
            BtnDeadlock.FlatAppearance.BorderSize = 0;
            BtnDeadlock.FlatStyle = FlatStyle.Flat;
            BtnDeadlock.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDeadlock.ForeColor = Color.White;
            BtnDeadlock.Location = new Point(-5, 528);
            BtnDeadlock.Name = "BtnDeadlock";
            BtnDeadlock.Size = new Size(207, 68);
            BtnDeadlock.TabIndex = 7;
            BtnDeadlock.Text = "Deadlock";
            BtnDeadlock.UseVisualStyleBackColor = false;
            BtnDeadlock.Click += BtnDeadlock_Click;
            // 
            // BtnPriority
            // 
            BtnPriority.BackColor = Color.FromArgb(64, 64, 64);
            BtnPriority.FlatAppearance.BorderColor = Color.White;
            BtnPriority.FlatAppearance.BorderSize = 0;
            BtnPriority.FlatStyle = FlatStyle.Flat;
            BtnPriority.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnPriority.ForeColor = Color.White;
            BtnPriority.Location = new Point(-5, 462);
            BtnPriority.Name = "BtnPriority";
            BtnPriority.Size = new Size(207, 72);
            BtnPriority.TabIndex = 6;
            BtnPriority.Text = "Priority";
            BtnPriority.UseVisualStyleBackColor = false;
            BtnPriority.Click += BtnPriority_Click;
            // 
            // BtnRR
            // 
            BtnRR.BackColor = Color.FromArgb(64, 64, 64);
            BtnRR.FlatAppearance.BorderColor = Color.White;
            BtnRR.FlatAppearance.BorderSize = 0;
            BtnRR.FlatStyle = FlatStyle.Flat;
            BtnRR.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRR.ForeColor = Color.White;
            BtnRR.Location = new Point(-5, 396);
            BtnRR.Name = "BtnRR";
            BtnRR.Size = new Size(207, 73);
            BtnRR.TabIndex = 5;
            BtnRR.Text = "RR";
            BtnRR.UseVisualStyleBackColor = false;
            BtnRR.Click += BtnRR_Click;
            // 
            // BtnSRTF
            // 
            BtnSRTF.BackColor = Color.FromArgb(64, 64, 64);
            BtnSRTF.FlatAppearance.BorderColor = Color.White;
            BtnSRTF.FlatAppearance.BorderSize = 0;
            BtnSRTF.FlatStyle = FlatStyle.Flat;
            BtnSRTF.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSRTF.ForeColor = Color.White;
            BtnSRTF.Location = new Point(-5, 330);
            BtnSRTF.Name = "BtnSRTF";
            BtnSRTF.Size = new Size(207, 72);
            BtnSRTF.TabIndex = 4;
            BtnSRTF.Text = "SRTF";
            BtnSRTF.UseVisualStyleBackColor = false;
            BtnSRTF.Click += BtnSRTF_Click;
            // 
            // BtnSJF
            // 
            BtnSJF.BackColor = Color.FromArgb(64, 64, 64);
            BtnSJF.FlatAppearance.BorderColor = Color.White;
            BtnSJF.FlatAppearance.BorderSize = 0;
            BtnSJF.FlatStyle = FlatStyle.Flat;
            BtnSJF.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSJF.ForeColor = Color.White;
            BtnSJF.Location = new Point(-5, 264);
            BtnSJF.Name = "BtnSJF";
            BtnSJF.Size = new Size(207, 70);
            BtnSJF.TabIndex = 3;
            BtnSJF.Text = "SJF";
            BtnSJF.UseVisualStyleBackColor = false;
            BtnSJF.Click += BtnSJF_Click;
            // 
            // BtnFCFS
            // 
            BtnFCFS.BackColor = Color.FromArgb(64, 64, 64);
            BtnFCFS.FlatAppearance.BorderColor = Color.White;
            BtnFCFS.FlatAppearance.BorderSize = 0;
            BtnFCFS.FlatStyle = FlatStyle.Flat;
            BtnFCFS.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnFCFS.ForeColor = Color.White;
            BtnFCFS.Location = new Point(-5, 198);
            BtnFCFS.Name = "BtnFCFS";
            BtnFCFS.Size = new Size(207, 68);
            BtnFCFS.TabIndex = 2;
            BtnFCFS.Text = "FCFS";
            BtnFCFS.UseVisualStyleBackColor = false;
            BtnFCFS.Click += BtnFCFS_Click;
            // 
            // BtnHome
            // 
            BtnHome.BackColor = Color.FromArgb(64, 64, 64);
            BtnHome.FlatAppearance.BorderColor = Color.White;
            BtnHome.FlatAppearance.BorderSize = 0;
            BtnHome.FlatStyle = FlatStyle.Flat;
            BtnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnHome.ForeColor = Color.White;
            BtnHome.Location = new Point(-5, 132);
            BtnHome.Name = "BtnHome";
            BtnHome.Size = new Size(207, 71);
            BtnHome.TabIndex = 1;
            BtnHome.Text = "Home";
            BtnHome.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(202, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1104, 708);
            panel2.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 708);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OSK50";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnHome;
        private Button BtnFCFS;
        private Button BtnOPT;
        private Button BtnDeadlock;
        private Button BtnPriority;
        private Button BtnRR;
        private Button BtnSRTF;
        private Button BtnSJF;
        private PictureBox pictureBox1;
        private Panel panel2;
    }
}
