using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class FIFO : Form
    {
        public FIFO()
        {
            InitializeComponent();
        }

        // ── Nút "Nhập" – tạo các dòng trong bảng chuỗi tham chiếu ──────────
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int count) || count < 1)
            {
                MessageBox.Show("Vui lòng nhập số trang hợp lệ (số nguyên > 0)!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            dataGridView1.Rows.Clear();
            for (int i = 1; i <= count; i++)
                dataGridView1.Rows.Add($"Trang {i}", "");
        }

        // ── Nút "Thực hiện" – chạy FIFO và hiển thị kết quả ────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int frameCount) || frameCount < 1)
            {
                MessageBox.Show("Vui lòng nhập số frame hợp lệ (số nguyên > 0)!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            var pages = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var val = row.Cells["colPageVal"].Value;
                if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                {
                    MessageBox.Show($"Dòng {row.Index + 1} chưa nhập số trang!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(val.ToString(), out int p) || p < 0)
                {
                    MessageBox.Show($"Dòng {row.Index + 1}: Số trang phải là số nguyên >= 0!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pages.Add(p);
            }

            if (pages.Count == 0)
            {
                MessageBox.Show("Bạn phải nhập chuỗi tham chiếu trước khi thực hiện!",
                    "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FIFOResult result = FIFOAlgorithm.RunFIFO(pages, frameCount);
            DisplayResult(result);
        }

        // ── Hiển thị kết quả lên dataGridView2 ──────────────────────────────
        private void DisplayResult(FIFOResult result)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            int n = result.Pages.Count;
            int f = result.FramesCount;

            // Cột tiêu đề cố định (frozen)
            var colTitle = new DataGridViewTextBoxColumn
            {
                Name = "Col_TieuDe",
                HeaderText = "Khung Trang",
                Width = 110,
                Frozen = true
            };
            colTitle.DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.Columns.Add(colTitle);

            // Cột mỗi bước tham chiếu (header = số trang)
            for (int i = 0; i < n; i++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = $"Col_{i}",
                    HeaderText = result.Pages[i].ToString(),
                    Width = 45
                };
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(col);
            }

            // Dòng cho từng frame
            for (int fr = 0; fr < f; fr++)
            {
                int rowIdx = dataGridView2.Rows.Add();
                dataGridView2.Rows[rowIdx].Cells[0].Value = $"Khung số {fr + 1}";
                for (int i = 0; i < n; i++)
                {
                    int val = result.Grid![fr, i];
                    dataGridView2.Rows[rowIdx].Cells[i + 1].Value = val == -1 ? "" : val.ToString();
                }
            }

            // Dòng trạng thái:
            // IsHit[i] == true  → thay thế trang thật sự → đánh F đỏ
            // IsHit[i] == false → nạp lần đầu hoặc hit   → để trống
            int statusRow = dataGridView2.Rows.Add();
            dataGridView2.Rows[statusRow].Cells[0].Value = "Trạng Thái";

            for (int i = 0; i < n; i++)
            {
                if (result.IsHit![i])
                {
                    dataGridView2.Rows[statusRow].Cells[i + 1].Value = "F";
                    dataGridView2.Rows[statusRow].Cells[i + 1].Style.BackColor = Color.LightPink;
                    dataGridView2.Rows[statusRow].Cells[i + 1].Style.ForeColor = Color.Red;
                }
                // else: để trống, không đánh H, không đánh F
            }
        }
    }
}