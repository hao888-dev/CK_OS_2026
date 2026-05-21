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

            // Kiểm tra số frame
            if (!int.TryParse(txtFrame.Text, out int frameCount) || frameCount < 1)
            {
                MessageBox.Show("Số frame phải >= 1");
                return;
            }

            // Lấy chuỗi tham chiếu
            string[] references = txtReference.Text
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => x != "")
                .ToArray();

            if (references.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi tham chiếu");
                return;
            }

            // =========================
            // Tạo cột DataGridView
            // =========================

            dataPage.Columns.Add("Frame", "Khung");

            for (int i = 0; i < references.Length; i++)
            {
                dataPage.Columns.Add("C" + i, references[i]);
            }

            // =========================
            // Tạo dòng Frame
            // =========================

            for (int i = 0; i < frameCount; i++)
            {
                dataPage.Rows.Add("Frame " + (i + 1));
            }

            // Dòng Fault
            dataPage.Rows.Add("F");

            // =========================
            // Clock Algorithm
            // =========================

            string[] frames = new string[frameCount];
            bool[] useBit = new bool[frameCount];

            int pointer = 0;

            for (int step = 0; step < references.Length; step++)
            {
                string page = references[step];

                bool hit = false;

                // =========================
                // Kiểm tra HIT
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

                // =========================
                // PAGE FAULT
                // =========================

                if (!hit)
                {
                    while (true)
                    {
                        // Frame trống
                        if (frames[pointer] == null)
                        {
                            frames[pointer] = page;
                            useBit[pointer] = true;

                            replacedIndex = pointer;

                            pointer = (pointer + 1) % frameCount;
                            break;
                        }

                        // Use bit = 0 => thay thế
                        if (useBit[pointer] == false)
                        {
                            frames[pointer] = page;
                            useBit[pointer] = true;

                            replacedIndex = pointer;

                            pointer = (pointer + 1) % frameCount;
                            break;
                        }
                        else
                        {
                            // Cho cơ hội thứ 2
                            useBit[pointer] = false;
                            pointer = (pointer + 1) % frameCount;
                        }
                    }
                }

                // =========================
                // Xuất dữ liệu ra bảng
                // =========================

                for (int i = 0; i < frameCount; i++)
                {
                    dataPage.Rows[i].Cells[step + 1].Value = frames[i];

                    // Reset màu
                    dataPage.Rows[i]
                            .Cells[step + 1]
                            .Style.BackColor = Color.White;

                    dataPage.Rows[i]
                            .Cells[step + 1]
                            .Style.ForeColor = Color.Black;
                }

                // =========================
                // Tô màu con trỏ Clock
                // =========================

                if (replacedIndex != -1)
                {
                    dataPage.Rows[replacedIndex]
                            .Cells[step + 1]
                            .Style.BackColor = Color.LightYellow;
                }

                // =========================
                // Dòng Fault
                // =========================

                // =========================
                // Đánh dấu F khi có thay đổi
                // =========================

                bool changed = false;

                if (step > 0)
                {
                    for (int i = 0; i < frameCount; i++)
                    {
                        string prev =
                            dataPage.Rows[i].Cells[step].Value?.ToString();

                        string curr =
                            dataPage.Rows[i].Cells[step + 1].Value?.ToString();

                        if (prev != curr)
                        {
                            changed = true;
                            break;
                        }
                    }
                }

                // Chỉ đánh dấu F khi frame đã full
                bool isFull = true;

                for (int i = 0; i < frameCount; i++)
                {
                    if (frames[i] == null)
                    {
                        isFull = false;
                        break;
                    }
                }

                if (changed && isFull)
                {
                    dataPage.Rows[frameCount]
                            .Cells[step + 1]
                            .Value = "F";

                    dataPage.Rows[frameCount]
                            .Cells[step + 1]
                            .Style.BackColor = Color.Red;

                    dataPage.Rows[frameCount]
                            .Cells[step + 1]
                            .Style.ForeColor = Color.White;
                }
            }

            // =========================
            // Format DataGridView
            // =========================

            dataPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataPage.RowHeadersVisible = false;

            dataPage.AllowUserToAddRows = false;

            dataPage.ReadOnly = true;

            dataPage.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataPage.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter; 
        }
    }
}
