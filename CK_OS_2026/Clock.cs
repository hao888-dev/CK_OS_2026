using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            dataPage.Rows.Clear();
            dataPage.Columns.Clear();

            // =========================
            // CHECK FRAME
            // =========================

            if (!int.TryParse(txtFrame.Text, out int frameCount) || frameCount < 1)
            {
                MessageBox.Show("Số frame phải >= 1");
                return;
            }

            // =========================
            // GET REFERENCE STRING
            // =========================

            string[] references = txtReference.Text.Split(',').Select(x => x.Trim()).Where(x => x != "").ToArray();

            if (references.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi tham chiếu");
                return;
            }

            // =========================
            // CREATE COLUMNS
            // =========================

            dataPage.Columns.Add("Frame", "Khung");
            for (int i = 0; i < references.Length; i++)
            {
                dataPage.Columns.Add("C" + i, references[i]);
            }

            // =========================
            // CREATE FRAME ROWS
            // =========================

            for (int i = 0; i < frameCount; i++)
            {
                dataPage.Rows.Add("Frame " + (i + 1));
            }

            dataPage.Rows.Add("F");

            // =========================
            // CLOCK ALGORITHM
            // =========================

            string[] frames = new string[frameCount];
            bool[] useBit = new bool[frameCount];
            int pointer = 0;

            for (int step = 0; step < references.Length; step++)
            {
                string page = references[step];
                bool hit = false;

                // =========================
                // CHECK HIT
                // =========================

                for (int i = 0; i < frameCount; i++)
                {
                    if (frames[i] == page)
                    {
                        useBit[i] = true;
                        hit = true;
                        break;
                    }
                }

                int replacedIndex = -1;
                bool replaced = false;

                // =========================
                // PAGE FAULT
                // =========================

                if (!hit)
                {
                    while (true)
                    {
                        // EMPTY FRAME

                        if (frames[pointer] == null)
                        {
                            frames[pointer] = page;
                            useBit[pointer] = true;
                            replacedIndex = pointer;
                            pointer = (pointer + 1) % frameCount;
                            break;
                        }

                        // REPLACE PAGE

                        if (useBit[pointer] == false)
                        {
                            replaced = true;
                            frames[pointer] = page;
                            useBit[pointer] = true;
                            replacedIndex = pointer;
                            pointer = (pointer + 1) % frameCount;
                            break;
                        }
                        else
                        {
                            // SECOND CHANCE

                            useBit[pointer] = false;
                            pointer = (pointer + 1) % frameCount;
                        }
                    }
                }

                // =========================
                // RENDER FRAME DATA
                // =========================

                for (int i = 0; i < frameCount; i++)
                {
                    dataPage.Rows[i].Cells[step + 1].Value = frames[i];
                    dataPage.Rows[i].Cells[step + 1].Style.BackColor = Color.White;
                    dataPage.Rows[i].Cells[step + 1].Style.ForeColor = Color.Black;
                }

                // =========================
                // CLOCK POINTER COLOR
                // =========================

                if (replacedIndex != -1)
                {
                    dataPage.Rows[replacedIndex].Cells[step + 1].Style.BackColor = Color.LightYellow;
                }

                // =========================
                // FAULT
                // =========================

                if (replaced)
                {
                    dataPage.Rows[frameCount].Cells[step + 1].Value = "F";
                    dataPage.Rows[frameCount].Cells[step + 1].Style.BackColor = Color.Red;
                    dataPage.Rows[frameCount].Cells[step + 1].Style.ForeColor = Color.White;
                }
            }

            // =========================
            // FORMAT DATAGRIDVIEW
            // =========================

            dataPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataPage.RowHeadersVisible = false;
            dataPage.AllowUserToAddRows = false;
            dataPage.ReadOnly = true;
            dataPage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataPage.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}