namespace CK_OS_2026
{
    public partial class Form1 : Form
    {
        private Button? currentButton;

        public Form1()
        {
            InitializeComponent();

            this.Load += MainForm_Load;

            BtnFCFS.Click += BtnFCFS_Click;
            BtnHome.Click += BtnHome_Click;
            BtnSJF.Click += BtnSJF_Click;
            BtnSRTF.Click += BtnSRTF_Click;
            BtnRR.Click += BtnRR_Click;
            BtnPriority.Click += BtnPriority_Click;
            BtnDeadlock.Click += BtnDeadlock_Click;
            BtnOPT.Click += BtnOPT_Click;
            BtnLRU.Click += BtnLRU_Click;
            BtnFIFO.Click += BtnFIFO_Click;
            BtnClock.Click += BtnClock_Click;
        }

        private void OpenChildForm(Form childForm)
        {
            panel2.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel2.Controls.Add(childForm);
            childForm.Show();
        }

        private void SelectButton(Button btn)
        {
            // reset nút cũ
            if (currentButton != null)
            {
                currentButton.BackColor = panel1.BackColor;
                currentButton.ForeColor = Color.White;
            }

            // nút đang được chọn
            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(70, 70, 70);
            currentButton.ForeColor = Color.White;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // chọn Home mặc định
            SelectButton(BtnHome);

            // load Home vào panel2
            OpenChildForm(new Home());
        }

        private void BtnFCFS_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnFCFS);
            OpenChildForm(new FCFS());
        }

        private void BtnHome_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnHome);
            OpenChildForm(new Home());
        }

        private void BtnSJF_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnSJF);
            OpenChildForm(new SJF());
        }

        private void BtnSRTF_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnSRTF);
            OpenChildForm(new SRTF());
        }

        private void BtnRR_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnRR);
            OpenChildForm(new RR());
        }

        private void BtnPriority_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnPriority);
            OpenChildForm(new Priority());
        }

        private void BtnDeadlock_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnDeadlock);
            OpenChildForm(new Deadlock());
        }

        private void BtnOPT_Click(object? sender, EventArgs e)
        {
            SelectButton(BtnOPT);
            OpenChildForm(new OPT());
        }

        private void BtnLRU_Click(object sender, EventArgs e)
        {
            SelectButton(BtnLRU);
            OpenChildForm(new LRU());
        }

        private void BtnFIFO_Click(object sender, EventArgs e)
        {
            SelectButton(BtnFIFO);
            OpenChildForm(new FIFO());
        }

        private void BtnClock_Click(object sender, EventArgs e)
        {
            SelectButton(BtnClock);
            OpenChildForm(new Clock());
        }
    }
}