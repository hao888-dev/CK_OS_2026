using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCodeSRTF;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CK_OS_2026
{
    public partial class Priority : Form
    {
        public Priority()
        {
            InitializeComponent();

            btnNhap.Click += BtnNhap_Click; // bấm nút nhập -> chạy code nhập dữ liệu
            btnThucHien.Click += BtnThucHien_Click; // bấm nút thực hiện -> thì tiến hành thực hiện chạy thuật toán, vẽ gantt các thứ

            dgvInput.AllowUserToAddRows = false; 
            dgvResults.AllowUserToAddRows = false;

            comboBox1.Items.Clear(); // xóa các lựa chọn mặc định của comboBox
            comboBox1.Items.Add("Non-Preemptive"); // lựa chọn chạy Non-Preemptive
            comboBox1.Items.Add("Preemptive");     // lựa chọn chạy Preemptive
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // khóa gõ văn bản, chỉ cho phép chọn
        }

        private void BtnNhap_Click(object? sender, EventArgs e)
        {
            dgvInput.Rows.Clear(); // clear hết sau khi thực hiện tránh người dùng bấm chạy 2 lần làm đè gantt

            if (int.TryParse(txtSoLuong.Text, out int n) && n > 0) // chuyển từ chuỗi sang số nguyên dương
            {
                for (int i = 0; i < n; i++)
                {
                    dgvInput.Rows.Add($"P{i + 1}", "0", "0", "0"); // thêm 1 hàng mới vào DataGridView => "P1" = tên process, "0" = giá trị mặc định cho AT BT PRI
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng Process là một số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnThucHien_Click(object? sender, EventArgs e)
        {
            if (dgvInput.Rows.Count == 0) // kiểm tra nhập dữ liệu chưa
            {
                MessageBox.Show("Vui lòng nhập số lượng và ấn nút 'Nhập' trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBox1.SelectedIndex == -1) // kiểm tra đã chọn loại thuật toán chưa
            {
                MessageBox.Show("Vui lòng chọn chế độ thuật toán (Non-Preemptive hoặc Preemptive) trước khi thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isPreemptive = (comboBox1.SelectedIndex == 1); // xác định chọn loại thuật toán => Non-Preemptive -> false, Preemptive-> true

            try
            {
                List<Process> processList = new List<Process>(); // tạo danh sách 
                foreach (DataGridViewRow row in dgvInput.Rows)
                {
                    string id = row.Cells["colID"].Value?.ToString() ?? ""; // lấy id
                    int at = int.Parse(row.Cells["colAT"].Value?.ToString() ?? "0"); // lấy Arrival Time
                    int bt = int.Parse(row.Cells["colBT"].Value?.ToString() ?? "0"); // lấy Burst Time
                    int pri = int.Parse(row.Cells["colPri"].Value?.ToString() ?? "0"); // lấy Priority

                    processList.Add(new Process(id, at, bt, pri)); 
                }

                PriorityScheduler scheduler = new PriorityScheduler(processList, isPreemptive); // truyền vào chuẩn bị chạy
                scheduler.Run(); // gọi thuật toán ra chạy

                dgvResults.Rows.Clear(); // xóa hết dữ liệu cũ để chuẩn bị hiển thị kết quả mới

                double totalWT = 0, totalRT = 0, totalTAT = 0; // khởi tạo các biến để tính trung bình

                int n = scheduler.process.Count;

                int maxEndTime = 0;

                foreach (var p in scheduler.process) 
                {
                    dgvResults.Rows.Add(p.ID!, p.waitingTime, p.responseTime, p.turnAroundTime);

                    // tính tổng các dữ liệu cần tính
                    totalWT += p.waitingTime;
                    totalRT += p.responseTime;
                    totalTAT += p.turnAroundTime;

                    int endTime = p.arrivalTime + p.turnAroundTime;
                    if (endTime > maxEndTime) maxEndTime = endTime;
                }

                // tính trung bình sau khi đã có tổng
                lblAvgWT.Text = (totalWT / n).ToString("0.00"); 
                lblAvgRT.Text = (totalRT / n).ToString("0.00");
                lblAvgTAT.Text = (totalTAT / n).ToString("0.00");

                // tính thông năng
                double throughput = maxEndTime > 0 ? (double)n / maxEndTime : 0;
                lblThroughput.Text = throughput.ToString("0.000");

                GanttRenderer.Draw(pnlGantt, pictureBoxGantt, scheduler.ganttData); // gọi hàm vẽ để tiến hành vẽ gantt
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}