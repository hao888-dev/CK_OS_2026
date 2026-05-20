using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public partial class Priority : Form
    {
        public Priority()
        {
            InitializeComponent();

            // gắn hàm xử lý sự kiện vào nút bấm
            btnNhap.Click += BtnNhap_Click;
            btnThucHien.Click += BtnThucHien_Click;

            // chặn người dùng tự click thêm dòng trống ở dưới cùng của bảng
            dgvInput.AllowUserToAddRows = false;
            dgvResults.AllowUserToAddRows = false;
        }

        private void BtnNhap_Click(object? sender, EventArgs e)
        {
            dgvInput.Rows.Clear(); // xóa dữ liệu cũ trên bảng

            // kiểm tra xem dữ liệu nhập có phải là số nguyên > 0
            if(int.TryParse(txtSoLuong.Text, out int n) && n > 0)
            {
                for(int i = 0; i < n; i++)
                {
                    // tạo n dòng với giá trị mặc định là 0, ID tự động tăng: P1, P2,...
                    dgvInput.Rows.Add($"P{i + 1}", "0", "0", "0");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng Process là một số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- Sự kiện khi nhấn nút THỰC HIỆN ---
        private void BtnThucHien_Click(object? sender, EventArgs e)
        {
            if(dgvInput.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng và ấn nút 'Nhập' trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                List<Process> processList = new List<Process>(); // đọc dữ liệu từ bảng gvInput để đưa vào danh sách Process
                foreach(DataGridViewRow row in dgvInput.Rows)
                {
                    string id = row.Cells["colID"].Value?.ToString() ?? "";
                    int at = int.Parse(row.Cells["colAT"].Value?.ToString() ?? "0");
                    int bt = int.Parse(row.Cells["colBT"].Value?.ToString() ?? "0");
                    int pri = int.Parse(row.Cells["colPri"].Value?.ToString() ?? "0");

                    processList.Add(new Process(id, at, bt, pri));
                }

                // gọi thuật toán Priority
                PriorityScheduler scheduler = new PriorityScheduler(processList);
                scheduler.Run();

                // hiển thị ra bảng dgvResults
                dgvResults.Rows.Clear(); // xóa dữ liệu để tránh nhấn nhiều lần thực hiện bảng dài thêm
                double totalWT = 0, totalRT = 0, totalTAT = 0; // cộng dồn 
                int n = scheduler.process.Count;
                int maxEndTime = 0;

                foreach(var p in scheduler.process)
                {
                    // đưa dữ liệu TurnAroundTime, WaitingTime, ResponseTime ra bảng
                    dgvResults.Rows.Add(p.ID, p.waitingTime, p.responseTime, p.turnAroundTime);

                    totalWT += p.waitingTime;
                    totalRT += p.responseTime;
                    totalTAT += p.turnAroundTime;

                    int endTime = p.arrivalTime + p.turnAroundTime; // tính thời điểm hoàn thành
                    if (endTime > maxEndTime) maxEndTime = endTime; // tìm thời điểm nghỉ lớn nhất
                }

                // tính toán và hiển thị thời gian trung bình, ép sang chuỗi để hiển thị
                lblAvgWT.Text = (totalWT / n).ToString("0.00");
                lblAvgRT.Text = (totalRT / n).ToString("0.00");
                lblAvgTAT.Text = (totalTAT / n).ToString("0.00");


                // công thức Thông lượng(Throughput) = Tổng số tiến trình / Tổng thời gian thực thi
                double throughput = maxEndTime > 0 ? (double)n / maxEndTime : 0;
                lblThroughput.Text = throughput.ToString("0.000");

                // gọi hàm vẽ
                GanttRenderer.Draw(pnlGantt, pictureBoxGantt, scheduler.ganttData);
            }

            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu trong bảng (AT, BT, Priority) phải là chữ số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
