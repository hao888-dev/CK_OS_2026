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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChayThuNghiemCuonDataGridView();
        }
        private void ChayThuNghiemCuonDataGridView()
        {
            // 1. Xóa sạch cột và dòng cũ (nếu có) để tránh cộng dồn khi bấm nhiều lần
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();

            // 2. Cấu hình cơ bản cho DataGridView
            dataGridView2.ScrollBars = ScrollBars.Both; // Bật cả cuộn dọc và cuộn ngang
            dataGridView2.AllowUserToAddRows = false;   // Tắt dòng trống mặc định ở cuối bảng
            dataGridView2.ReadOnly = true;              // Chỉ cho xem, không cho sửa bậy

            // 3. Tạo cột đầu tiên và GHIM cố định (Frozen) giống như Excel
            DataGridViewTextBoxColumn colTieuDe = new DataGridViewTextBoxColumn();
            colTieuDe.Name = "Col_TieuDe";
            colTieuDe.HeaderText = "Khung Trang";
            colTieuDe.Width = 110;
            colTieuDe.Frozen = true; // Thằng này sẽ đứng yên khi bạn cuộn ngang sang phải
            colTieuDe.DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.Columns.Add(colTieuDe);

            // 4. Vòng lặp tạo thêm 30 cột để ép DataGridView phải xuất hiện thanh cuộn ngang
            for (int i = 1; i <= 30; i++)
            {
                DataGridViewTextBoxColumn colBuoc = new DataGridViewTextBoxColumn();
                colBuoc.Name = $"Col_Buoc{i}";
                colBuoc.HeaderText = $"B.{i}"; // Tiêu đề cột ngắn gọn (Bước 1, Bước 2...)
                colBuoc.Width = 45;            // Thu nhỏ độ rộng để vừa khít chữ số
                colBuoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa
                dataGridView2.Columns.Add(colBuoc);
            }

            // 5. Thêm Dòng 1 (Mô phỏng dữ liệu Khung 1)
            int r1 = dataGridView2.Rows.Add();
            dataGridView2.Rows[r1].Cells[0].Value = "Khung số 1";
            for (int i = 1; i <= 30; i++)
            {
                dataGridView2.Rows[r1].Cells[i].Value = (i % 4 == 0) ? "" : (i % 3).ToString();
            }

            // 6. Thêm Dòng 2 (Mô phỏng dữ liệu Khung 2)
            int r2 = dataGridView2.Rows.Add();
            dataGridView2.Rows[r2].Cells[0].Value = "Khung số 2";
            for (int i = 1; i <= 30; i++)
            {
                dataGridView2.Rows[r2].Cells[i].Value = (i % 5 == 0) ? "" : (i % 2).ToString();
            }

            // 7. Thêm Dòng 3 (Dòng Trạng Thái / Kết quả - Có tô màu để check độ mượt)
            int r3 = dataGridView2.Rows.Add();
            dataGridView2.Rows[r3].Cells[0].Value = "Trạng Thái";
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    dataGridView2.Rows[r3].Cells[i].Value = "F"; // Fault
                    dataGridView2.Rows[r3].Cells[i].Style.BackColor = Color.LightPink; // Tô nền đỏ nhạt
                    dataGridView2.Rows[r3].Cells[i].Style.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView2.Rows[r3].Cells[i].Value = "H"; // Hit
                    dataGridView2.Rows[r3].Cells[i].Style.BackColor = Color.LightGreen; // Tô nền xanh nhạt
                    dataGridView2.Rows[r3].Cells[i].Style.ForeColor = Color.Green;
                }
            }
        }
    }
}
