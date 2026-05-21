namespace CK_OS_2026
{
    partial class Clock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            label9 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtFrame = new TextBox();
            txtReference = new TextBox();
            btnConfirm = new Button();
            dataPage = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataPage).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.Font = new Font("Sitka Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(-1, 0);
            label9.Name = "label9";
            label9.Size = new Size(94, 39);
            label9.TabIndex = 18;
            label9.Text = "Clock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(25, 55);
            label1.Name = "label1";
            label1.Size = new Size(116, 21);
            label1.TabIndex = 19;
            label1.Text = "Nhập số Frame";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(25, 105);
            label2.Name = "label2";
            label2.Size = new Size(202, 21);
            label2.TabIndex = 20;
            label2.Text = "Nhập tham chiếu trang nhớ";
            // 
            // txtFrame
            // 
            txtFrame.Location = new Point(25, 79);
            txtFrame.Name = "txtFrame";
            txtFrame.Size = new Size(227, 23);
            txtFrame.TabIndex = 21;
            // 
            // txtReference
            // 
            txtReference.Location = new Point(25, 129);
            txtReference.Name = "txtReference";
            txtReference.Size = new Size(227, 23);
            txtReference.TabIndex = 22;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(280, 129);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 23;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // dataPage
            // 
            dataPage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataPage.Location = new Point(25, 207);
            dataPage.Name = "dataPage";
            dataPage.Size = new Size(853, 226);
            dataPage.TabIndex = 24;
            // 
            // Clock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 530);
            Controls.Add(dataPage);
            Controls.Add(btnConfirm);
            Controls.Add(txtReference);
            Controls.Add(txtFrame);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label9);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Clock";
            Text = "Clock";
            ((System.ComponentModel.ISupportInitialize)dataPage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label1;
        private Label label2;
        private TextBox txtFrame;
        private TextBox txtReference;
        private Button btnConfirm;
        private DataGridView dataPage;
    }
}