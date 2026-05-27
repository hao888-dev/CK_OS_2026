using CK_OS_2026.deadlockBanker;
using System;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class Deadlock_Input : Form
    {
        // =====================================
        // RETURN DATA
        // =====================================

        public BankerData? Data;

        // =====================================
        // LOCAL VARIABLES
        // =====================================

        int process;
        int resource;

        // =====================================
        // CONSTRUCTOR
        // =====================================

        public Deadlock_Input()
        {
            InitializeComponent();
        }

        // =====================================
        // CREATE TABLE BUTTON
        // =====================================

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã nhập cả 2 ô chưa
            if (string.IsNullOrWhiteSpace(txtProcess.Text) || string.IsNullOrWhiteSpace(txtResource.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ cả Process và Thành phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ép kiểu an toàn và kiểm tra điều kiện số nguyên dương dưới 100
            bool isProcessValid = int.TryParse(txtProcess.Text, out process);
            bool isResourceValid = int.TryParse(txtResource.Text, out resource);

            // Kiểm tra: Phải là số nguyên hợp lệ, lớn hơn 0 và nhỏ hơn 100
            if (!isProcessValid || !isResourceValid || process <= 0 || process >= 100 || resource <= 0 || resource >= 100)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương cho cả Process và Thành phần.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Nếu dữ liệu đã hợp lệ, thực thi các hàm tiếp theo
            CreateInstanceTable();
            CreateAllocationTable();
            CreateMaxTable();
        }

        // =====================================
        // INSTANCE TABLE
        // =====================================

        private void CreateInstanceTable()
        {
            dgvInstance.Columns.Clear();
            dgvInstance.Rows.Clear();
            dgvInstance.AllowUserToAddRows = false;
            dgvInstance.RowHeadersVisible = false;

            // resource columns

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);
                dgvInstance.Columns.Add(c.ToString(), c.ToString());
            }

            foreach (DataGridViewColumn col in dgvInstance.Columns)
            {
                col.Width = 100;
            }

            // only 1 row

            dgvInstance.Rows.Add();
        }

        // =====================================
        // ALLOCATION TABLE
        // =====================================

        private void CreateAllocationTable()
        {
            dgvAllocation.Columns.Clear();
            dgvAllocation.Rows.Clear();
            dgvAllocation.AllowUserToAddRows = false;
            dgvAllocation.RowHeadersVisible = false;

            // process column

            dgvAllocation.Columns.Add("Process", "Process");

            // resource columns

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);
                dgvAllocation.Columns.Add(c.ToString(), c.ToString());
            }

            foreach (DataGridViewColumn col in dgvAllocation.Columns)
            {
                col.Width = 100;
            }

            // rows

            for (int i = 0; i < process; i++)
            {
                dgvAllocation.Rows.Add();
                dgvAllocation.Rows[i].Cells[0].Value = "P" + i;
                dgvAllocation.Rows[i].Cells[0].ReadOnly = true;
            }
        }

        // =====================================
        // MAX TABLE
        // =====================================

        private void CreateMaxTable()
        {
            dgvMax.Columns.Clear();
            dgvMax.Rows.Clear();
            dgvMax.AllowUserToAddRows = false;
            dgvMax.RowHeadersVisible = false;

            // process column

            dgvMax.Columns.Add("Process", "Process");

            // resource columns

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);
                dgvMax.Columns.Add(c.ToString(), c.ToString());
            }

            foreach (DataGridViewColumn col in dgvMax.Columns)
            {
                col.Width = 100;
            }

            // rows

            for (int i = 0; i < process; i++)
            {
                dgvMax.Rows.Add();
                dgvMax.Rows[i].Cells[0].Value = "P" + i;
                dgvMax.Rows[i].Cells[0].ReadOnly = true;
            }
        }

        // =====================================
        // SAVE BUTTON
        // =====================================

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // =====================================
                // CREATE ARRAYS
                // =====================================

                int[] instance = new int[resource];
                int[,] allocation = new int[process, resource];
                int[,] max = new int[process, resource];

                // =====================================
                // INSTANCE
                // =====================================

                for (int j = 0; j < resource; j++)
                {
                    instance[j] = Convert.ToInt32(dgvInstance.Rows[0].Cells[j].Value);
                }

                // =====================================
                // ALLOCATION + MAX
                // =====================================

                for (int i = 0; i < process; i++)
                {
                    for (int j = 0; j < resource; j++)
                    {
                        allocation[i, j] = Convert.ToInt32(dgvAllocation.Rows[i].Cells[j + 1].Value);
                        max[i, j] = Convert.ToInt32(dgvMax.Rows[i].Cells[j + 1].Value);
                    }
                }

                // =====================================
                // CREATE DATA OBJECT
                // =====================================

                Data = new BankerData()
                {
                    ProcessCount = process,
                    ResourceCount = resource,
                    Instance = instance,
                    Allocation = allocation,
                    Max = max
                };

                // =====================================
                // SUCCESS
                // =====================================

                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng và đủ dữ liệu");
            }
        }
    }
}