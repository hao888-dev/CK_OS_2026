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

            // THÊM 2 DÒNG NÀY ĐỂ KẾT NỐI NÚT BẤM VỚI HÀM XỬ LÝ
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
        }

        // ==========================================
        // 1. XỬ LÝ NÚT "NHẬP" ĐỂ TẠO DÒNG NHẬP CHUỖI
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int soTrang) && soTrang > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = false;

                for (int i = 0; i < soTrang; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng trang hợp lệ (>0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // 2. XỬ LÝ NÚT "THỰC HIỆN" ĐỂ CHẠY OPT
        // ==========================================
        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy chuỗi tham chiếu từ dataGridView1
            List<int> pages = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int val))
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

        // ==========================================
        // 3. HÀM HIỂN THỊ DỮ LIỆU THẬT LÊN DATAGRIDVIEW2
        // ==========================================
        private void HienThiKetQuaThucTe(OPTResult result)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            // Cột tiêu đề ghim (Frozen)
            DataGridViewTextBoxColumn colTieuDe = new DataGridViewTextBoxColumn();
            colTieuDe.Name = "Col_TieuDe";
            colTieuDe.HeaderText = $"Page Fault: {result.PageFaults}"; // Hiển thị tổng số lỗi trang ở góc
            colTieuDe.Width = 110;
            colTieuDe.Frozen = true;
            colTieuDe.DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.Columns.Add(colTieuDe);

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
                if (!result.IsHit[i])
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "F";
                    dataGridView2.Rows[rState].Cells[i + 1].Style.BackColor = Color.LightPink;
                    dataGridView2.Rows[rState].Cells[i + 1].Style.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "H";
                    dataGridView2.Rows[rState].Cells[i + 1].Style.BackColor = Color.LightGreen;
                    dataGridView2.Rows[rState].Cells[i + 1].Style.ForeColor = Color.Green;
                }
            }
        }
    }
}