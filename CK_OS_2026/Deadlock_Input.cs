using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class Deadlock_Input : Form
    {
        // =====================================
        // DATA RETURN TO MAIN FORM
        // =====================================

        public int ProcessCount;
        public int ResourceCount;

        public int[] Instance;

        public int[,] Allocation;
        public int[,] Max;

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
        // RENDER BUTTON
        // =====================================
        private void button1_Click(object sender, EventArgs e)
        {
            // check empty

            if (txtProcess.Text == "" || txtResource.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Process và Thành phần");
                return;
            }

            process = int.Parse(txtProcess.Text);

            resource = int.Parse(txtResource.Text);

            // create tables

            CreateInstanceTable();

            CreateAllocationTable();

            CreateMaxTable();

        }
        // =====================================
        // CREATE INSTANCE TABLE
        // =====================================

        private void CreateInstanceTable()
        {
            dgvInstance.Columns.Clear();

            dgvInstance.Rows.Clear();

            dgvInstance.AllowUserToAddRows = false;

            dgvInstance.RowHeadersVisible = false;

            // create columns A B C D

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);

                dgvInstance.Columns.Add(
                    c.ToString(),
                    c.ToString()
                );
            }

            // only 1 row

            dgvInstance.Rows.Add();
        }
        // =====================================
        // CREATE ALLOCATION TABLE
        // =====================================

        private void CreateAllocationTable()
        {
            dgvAllocation.Columns.Clear();

            dgvAllocation.Rows.Clear();

            dgvAllocation.AllowUserToAddRows = false;

            dgvAllocation.RowHeadersVisible = false;

            // Process column

            dgvAllocation.Columns.Add(
                "Process",
                "Process"
            );

            // resource columns

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);

                dgvAllocation.Columns.Add(
                    c.ToString(),
                    c.ToString()
                );
            }

            // create rows

            for (int i = 0; i < process; i++)
            {
                dgvAllocation.Rows.Add();

                dgvAllocation.Rows[i]
                    .Cells[0]
                    .Value = "P" + i;
            }
        }

        // =====================================
        // CREATE MAX TABLE
        // =====================================

        private void CreateMaxTable()
        {
            dgvMax.Columns.Clear();

            dgvMax.Rows.Clear();

            dgvMax.AllowUserToAddRows = false;

            dgvMax.RowHeadersVisible = false;

            // Process column

            dgvMax.Columns.Add(
                "Process",
                "Process"
            );

            // resource columns

            for (int i = 0; i < resource; i++)
            {
                char c = (char)('A' + i);

                dgvMax.Columns.Add(
                    c.ToString(),
                    c.ToString()
                );
            }

            // create rows

            for (int i = 0; i < process; i++)
            {
                dgvMax.Rows.Add();

                dgvMax.Rows[i]
                    .Cells[0]
                    .Value = "P" + i;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // =====================================
                // SAVE BASIC INFO
                // =====================================

                ProcessCount = process;

                ResourceCount = resource;

                // =====================================
                // SAVE INSTANCE
                // =====================================

                Instance = new int[resource];

                for (int j = 0; j < resource; j++)
                {
                    Instance[j] = Convert.ToInt32(
                        dgvInstance.Rows[0]
                        .Cells[j]
                        .Value
                    );
                }

                // =====================================
                // SAVE ALLOCATION + MAX
                // =====================================

                Allocation = new int[process, resource];

                Max = new int[process, resource];

                for (int i = 0; i < process; i++)
                {
                    for (int j = 0; j < resource; j++)
                    {
                        Allocation[i, j]
                            = Convert.ToInt32(
                                dgvAllocation.Rows[i]
                                .Cells[j + 1]
                                .Value
                            );

                        Max[i, j]
                            = Convert.ToInt32(
                                dgvMax.Rows[i]
                                .Cells[j + 1]
                                .Value
                            );
                    }
                }

                // =====================================
                // RETURN SUCCESS
                // =====================================

                DialogResult = DialogResult.OK;

                Close();
            }
            catch
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ dữ liệu"
                );
            }
        }
    }
}
