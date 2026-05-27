using CK_OS_2026.deadlockBanker;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class Deadlock : Form
    {
        public Deadlock()
        {
            InitializeComponent();
        }

        // =====================================
        // OPEN INPUT FORM
        // =====================================

        private void button1_Click(object sender, EventArgs e)
        {
            Deadlock_Input f = new Deadlock_Input();

            if (f.ShowDialog() == DialogResult.OK)
            {
                BankerAlgorithm banker = new BankerAlgorithm();
                BankerResult result = banker.Run(f.Data!);
                RenderFullTable(f.Data!, result);
            }
        }

        // =====================================
        // RENDER TABLE
        // =====================================

        private void RenderFullTable(BankerData data, BankerResult result)
        {
            dgvMain.Columns.Clear();
            dgvMain.Rows.Clear();
            dgvMain.AllowUserToAddRows = false;
            dgvMain.RowHeadersVisible = false;

            int process = data.ProcessCount;
            int resource = data.ResourceCount;

            // =====================================
            // CREATE COLUMNS
            // =====================================

            dgvMain.Columns.Add("Process", "Process");

            // Allocation

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);
                dgvMain.Columns.Add("Alloc" + c, "Allocation " + c);
            }

            // Max

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);
                dgvMain.Columns.Add("Max" + c, "Max " + c);
            }

            // Available

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);
                dgvMain.Columns.Add("Avail" + c, "Available " + c);
            }

            // Need

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);
                dgvMain.Columns.Add("Need" + c, "Need " + c);
            }

            foreach (DataGridViewColumn col in dgvMain.Columns)
            {
                col.Width = 100;
            }

            // Finish

            dgvMain.Columns.Add("Finish", "Finish");

            // =====================================
            // RENDER ROWS
            // =====================================

            for (int i = 0; i < process; i++)
            {
                dgvMain.Rows.Add();
                int col = 0;

                // Process

                dgvMain.Rows[i].Cells[col++].Value = "P" + i;

                // Allocation

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i].Cells[col++].Value = data.Allocation[i, j];
                }

                // Max

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i].Cells[col++].Value = data.Max[i, j];
                }

                // Available

                if (i < result.AvailableSteps.Count)
                {
                    for (int j = 0; j < resource; j++)
                    {
                        dgvMain.Rows[i].Cells[col++].Value = result.AvailableSteps[i][j];
                    }
                }
                else
                {
                    col += resource;
                }

                // Need

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i].Cells[col++].Value = result.Need[i, j];
                }

                // Finish

                dgvMain.Rows[i].Cells[col].Value = result.Order[i];
            }

            // =====================================
            // LAST AVAILABLE ROW
            // =====================================

            dgvMain.Rows.Add();

            int lastRow = dgvMain.Rows.Count - 1;
            int startCol = 1 + resource + resource;
            for (int j = 0; j < resource; j++)
            {
                dgvMain.Rows[lastRow].Cells[startCol + j].Value = result.AvailableSteps[result.AvailableSteps.Count - 1][j];
            }

            // =====================================
            // SAFE SEQUENCE
            // =====================================

            if (result.IsSafe)
            {
                lblSafe.Text = "Chuỗi an toàn: " + string.Join(" -> ", result.SafeSequence);
            }
            else
            {
                lblSafe.Text = "Chuỗi an toàn: null";
            }
        }
    }
}