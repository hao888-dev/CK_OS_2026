using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class Deadlock : Form
    {

        public Deadlock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deadlock_Input f = new Deadlock_Input();

            if (f.ShowDialog() == DialogResult.OK)
            {
                RenderFullTable(
                    f.ProcessCount,
                    f.ResourceCount,
                    f.Instance,
                    f.Allocation,
                    f.Max
                );
            }

        }
        // =====================================
        // RENDER FULL TABLE
        // =====================================

        private void RenderFullTable(
            int process,
            int resource,
            int[] instance,
            int[,] allocation,
            int[,] max)
        {
            dgvMain.Columns.Clear();

            dgvMain.Rows.Clear();

            dgvMain.AllowUserToAddRows = false;

            dgvMain.RowHeadersVisible = false;

            dgvMain.AutoSizeColumnsMode
                = DataGridViewAutoSizeColumnsMode.Fill;

            // =====================================
            // NEED
            // =====================================

            int[,] need = new int[process, resource];

            for (int i = 0; i < process; i++)
            {
                for (int j = 0; j < resource; j++)
                {
                    need[i, j]
                        = max[i, j]
                        - allocation[i, j];
                }
            }

            // =====================================
            // AVAILABLE
            // =====================================

            int[] available = new int[resource];

            for (int j = 0; j < resource; j++)
            {
                int sum = 0;

                for (int i = 0; i < process; i++)
                {
                    sum += allocation[i, j];
                }

                available[j]
                    = instance[j] - sum;
            }

            // =====================================
            // CREATE COLUMNS
            // =====================================

            dgvMain.Columns.Add(
                "Process",
                "Process"
            );

            // Allocation

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);

                dgvMain.Columns.Add(
                    "Alloc" + c,
                    "Allocation " + c
                );
            }

            // Max

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);

                dgvMain.Columns.Add(
                    "Max" + c,
                    "Max " + c
                );
            }

            // Available

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);

                dgvMain.Columns.Add(
                    "Avail" + c,
                    "Available " + c
                );
            }

            // Need

            for (int j = 0; j < resource; j++)
            {
                char c = (char)('A' + j);

                dgvMain.Columns.Add(
                    "Need" + c,
                    "Need " + c
                );
            }

            // Finish order

            dgvMain.Columns.Add(
                "Finish",
                "Finish"
            );

            // =====================================
            // BANKER ALGORITHM
            // =====================================

            bool[] finish = new bool[process];

            int[] order = new int[process];

            List<int[]> availableSteps
                = new List<int[]>();

            availableSteps.Add(
                (int[])available.Clone()
            );

            int step = 1;

            bool found;

            do
            {
                found = false;

                for (int i = 0; i < process; i++)
                {
                    if (!finish[i])
                    {
                        bool canRun = true;

                        for (int j = 0; j < resource; j++)
                        {
                            if (need[i, j]
                                > available[j])
                            {
                                canRun = false;
                                break;
                            }
                        }

                        if (canRun)
                        {
                            for (int j = 0; j < resource; j++)
                            {
                                available[j]
                                    += allocation[i, j];
                            }

                            finish[i] = true;

                            order[i] = step;

                            step++;

                            availableSteps.Add(
                                (int[])available.Clone()
                            );

                            found = true;
                        }
                    }
                }

            } while (found);

            // =====================================
            // RENDER ROWS
            // =====================================

            for (int i = 0; i < process; i++)
            {
                dgvMain.Rows.Add();

                int col = 0;

                // Process

                dgvMain.Rows[i]
                    .Cells[col++]
                    .Value = "P" + i;

                // Allocation

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i]
                        .Cells[col++]
                        .Value = allocation[i, j];
                }

                // Max

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i]
                        .Cells[col++]
                        .Value = max[i, j];
                }

                // Available

                if (i < availableSteps.Count)
                {
                    for (int j = 0; j < resource; j++)
                    {
                        dgvMain.Rows[i]
                            .Cells[col++]
                            .Value =
                            availableSteps[i][j];
                    }
                }
                else
                {
                    col += resource;
                }

                // Need

                for (int j = 0; j < resource; j++)
                {
                    dgvMain.Rows[i]
                        .Cells[col++]
                        .Value = need[i, j];
                }

                // Finish

                dgvMain.Rows[i]
                    .Cells[col]
                    .Value = order[i];
            }

            // =====================================
            // LAST AVAILABLE ROW
            // =====================================

            dgvMain.Rows.Add();

            int lastRow = dgvMain.Rows.Count - 1;

            int startCol
                = 1 + resource + resource;

            for (int j = 0; j < resource; j++)
            {
                dgvMain.Rows[lastRow]
                    .Cells[startCol + j]
                    .Value =
                    availableSteps[
                        availableSteps.Count - 1
                    ][j];
            }

            // =====================================
            // SAFE SEQUENCE
            // =====================================

            List<string> safe
                = new List<string>();

            for (int s = 1; s < step; s++)
            {
                for (int i = 0; i < process; i++)
                {
                    if (order[i] == s)
                    {
                        safe.Add("P" + i);
                    }
                }
            }

            if (safe.Count == process)
            {
                lblSafe.Text =
                    "Chuỗi an toàn: "
                    + string.Join(
                        " -> ",
                        safe
                    );
            }
            else
            {
                lblSafe.Text =
                    "Chuỗi an toàn: null";
            }
        }
    }
}
    

