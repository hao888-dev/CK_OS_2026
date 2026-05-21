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

            btnNhap.Click += BtnNhap_Click;
            btnThucHien.Click += BtnThucHien_Click;

            dgvInput.AllowUserToAddRows = false;
            dgvResults.AllowUserToAddRows = false;

            // --- THÊM: Thiết lập ComboBox ---
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Non-Preemptive"); // Index 0
            comboBox1.Items.Add("Preemptive");     // Index 1
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Khóa gõ văn bản, chỉ cho phép chọn
        }

        private void BtnNhap_Click(object? sender, EventArgs e)
        {
            dgvInput.Rows.Clear();

            if (int.TryParse(txtSoLuong.Text, out int n) && n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    dgvInput.Rows.Add($"P{i + 1}", "0", "0", "0");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng Process là một số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnThucHien_Click(object? sender, EventArgs e)
        {
            if (dgvInput.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng và ấn nút 'Nhập' trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- THÊM: Bắt buộc người dùng chọn trong ComboBox ---
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chế độ thuật toán (Non-Preemptive hoặc Preemptive) trước khi thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định xem có phải Preemptive không dựa vào index của ComboBox (1 = Preemptive)
            bool isPreemptive = (comboBox1.SelectedIndex == 1);

            try
            {
                List<Process> processList = new List<Process>();
                foreach (DataGridViewRow row in dgvInput.Rows)
                {
                    string id = row.Cells["colID"].Value?.ToString() ?? "";
                    int at = int.Parse(row.Cells["colAT"].Value?.ToString() ?? "0");
                    int bt = int.Parse(row.Cells["colBT"].Value?.ToString() ?? "0");
                    int pri = int.Parse(row.Cells["colPri"].Value?.ToString() ?? "0");

                    processList.Add(new Process(id, at, bt, pri));
                }

                // --- THAY ĐỔI: Truyền cờ isPreemptive vào Scheduler ---
                PriorityScheduler scheduler = new PriorityScheduler(processList, isPreemptive);
                scheduler.Run();

                dgvResults.Rows.Clear();
                double totalWT = 0, totalRT = 0, totalTAT = 0;
                int n = scheduler.process.Count;
                int maxEndTime = 0;

                foreach (var p in scheduler.process)
                {
                    dgvResults.Rows.Add(p.ID, p.waitingTime, p.responseTime, p.turnAroundTime);

                    totalWT += p.waitingTime;
                    totalRT += p.responseTime;
                    totalTAT += p.turnAroundTime;

                    int endTime = p.arrivalTime + p.turnAroundTime;
                    if (endTime > maxEndTime) maxEndTime = endTime;
                }

                lblAvgWT.Text = (totalWT / n).ToString("0.00");
                lblAvgRT.Text = (totalRT / n).ToString("0.00");
                lblAvgTAT.Text = (totalTAT / n).ToString("0.00");

                double throughput = maxEndTime > 0 ? (double)n / maxEndTime : 0;
                lblThroughput.Text = throughput.ToString("0.000");

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể để trống nếu chỉ lấy giá trị lúc ấn nút "Thực hiện"
        }
    }
}