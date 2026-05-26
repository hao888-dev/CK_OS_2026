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
    public partial class OPT : Form
    {
        public OPT()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click!);
            button2.Click += new EventHandler(button2_Click!);
        }

        private void button1_Click(object sender, EventArgs e) // bấm button 1 thì hàm này sẽ chạy
        {
            if (int.TryParse(textBox1.Text, out int soTrang) && soTrang > 0 && soTrang <= 50) // ép chuỗi thành số nguyên và phải lớn hơn 0
            {
                dataGridView1.Rows.Clear(); // clear hết những dữ liệu cũ

                dataGridView1.AllowUserToAddRows = false; // DataGridView mặc định hay có dòng cuối thì lệnh này tắt nó đi

                for (int i = 0; i < soTrang; i++) // tạo dòng để nhập dữ liệu 
                {
                    dataGridView1.Rows.Add();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng trang hợp lệ (> 0 hoặc <= 50)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e) // chạy opt
        {
            // Lấy chuỗi tham chiếu từ dataGridView1
            List<int> pages = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value!.ToString(), out int val))
                {
                    pages.Add(val);
                }
            }

            if (pages.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi tham chiếu trang nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy số Frame
            if (!int.TryParse(textBox2.Text, out int frames) || frames <= 0)
            {
                MessageBox.Show("Vui lòng nhập số frame hợp lệ (>0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi thuật toán
            OPTResult result = OPTAlgorithm.RunOPT(pages, frames);

            // Hiển thị ra bảng
            HienThiKetQuaThucTe(result);
        }

        private void HienThiKetQuaThucTe(OPTResult result)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột tiêu đề ghim (Frozen)
            DataGridViewTextBoxColumn colTieuDe = new DataGridViewTextBoxColumn();
            colTieuDe.Name = "Col_TieuDe";
            colTieuDe.HeaderText = $"Page Fault: {result.PageFaults}"; // Hiển thị tổng số lỗi trang ở góc
            colTieuDe.Width = 110;
            colTieuDe.Frozen = true;
            colTieuDe.DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.Columns.Add(colTieuDe);

            colTieuDe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Tạo các cột ứng với từng bước
            for (int i = 0; i < result.Pages.Count; i++)
            {
                DataGridViewTextBoxColumn colBuoc = new DataGridViewTextBoxColumn();
                colBuoc.Name = $"Col_Buoc{i}";
                colBuoc.HeaderText = result.Pages[i].ToString(); // Tiêu đề cột là trang tham chiếu
                colBuoc.Width = 45;
                colBuoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(colBuoc);
            }

            // Thêm các dòng Frame
            for (int f = 0; f < result.FramesCount; f++)
            {
                int rIndex = dataGridView2.Rows.Add();
                dataGridView2.Rows[rIndex].Cells[0].Value = $"Khung số {f + 1}";

                for (int i = 0; i < result.Pages.Count; i++)
                {
                    int val = result.Grid[f, i];
                    // Nếu giá trị khác -1 thì in ra, ngược lại để rỗng
                    dataGridView2.Rows[rIndex].Cells[i + 1].Value = (val != -1) ? val.ToString() : "";
                }
            }

            // Thêm dòng Trạng thái
            int rState = dataGridView2.Rows.Add();
            dataGridView2.Rows[rState].Cells[0].Value = "Trạng Thái";

            for (int i = 0; i < result.Pages.Count; i++)
            {
                if (result.IsReplacement[i]) // Chỉ in F khi khung nhớ đã đầy và xảy ra Thay Thế
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "F";
                    dataGridView2.Rows[rState].Cells[i + 1].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                    dataGridView2.Rows[rState].Cells[i + 1].Style.ForeColor = Color.Black;
                }
                else // Lỗi trang nạp mới (chưa đầy) hoặc Hit đều bỏ trống
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "";
                }
            }
        }
    }
}