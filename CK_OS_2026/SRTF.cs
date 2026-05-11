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
    public partial class SRTF : Form
    {
        private List<Process> processedResults = new List<Process>();
        private List<(string ProcessId, int Start, int End)> ganttChartData = new List<(string, int, int)>();
        public SRTF()
        {
            InitializeComponent();
        }

        private void createBang()
        {
            if (int.TryParse(txtRowCount.Text, out int rows) && rows > 0)
            {
                dgvData.Rows.Clear();
                
                for (int i = 1; i <= rows; i++)
                {
                    dgvData.Rows.Add("P" + i, 0, 0);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Thông báo");
                
                txtRowCount.Clear();
                txtRowCount.Focus();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            createBang();
        }

        private void txtRowCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createBang();
                e.SuppressKeyPress = true;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra bảng có dữ liệu chưa
            var dataRows = dgvData.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToList();

            if (dataRows.Count == 0)
            {
                MessageBox.Show("Bạn phải tạo và nhập dữ liệu trước khi lập lịch!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRowCount.Focus();
                return;
            }
            // Kiểm tra dữ liệu trong DataGridView trước khi tiến hành thuật toán
            if (!CheckDataGridView())
            {
                return;
            }

            // Chuyển đổi dữ liệu từ DataGridView thành danh sách Process
            List<Process> inputProcesses = dgvData.Rows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new Process(
                    row.Cells[0].Value!.ToString() ?? "Unknown", // ID
                    Convert.ToInt32(row.Cells["colArrival"].Value),
                    Convert.ToInt32(row.Cells["colBurst"].Value)
                )).ToList();
            // Khởi tạo Scheduler và chạy thuật toán
            SRTFScheduler scheduler = new SRTFScheduler(inputProcesses);
            scheduler.Run();
            // Lưu lại kết quả
            processedResults = inputProcesses;
            ganttChartData = scheduler.GanttData;
            // Hiển thị kết quả
            DisplayResults();
            DrawGanttChart();
        }

        private void DisplayResults()
        {
            dgvResults.Rows.Clear();
            dgvResults.Visible = true;

            // Đổ dữ liệu vào bảng kết quả
            processedResults.ForEach(p =>
            {
                dgvResults.Rows.Add(p.Id, p.WaitingTime, p.ResponseTime, p.TurnaroundTime);
            });

            // Tính toán trung bình bằng Lambda
            double avgWT = processedResults.Average(p => p.WaitingTime);
            double avgRT = processedResults.Average(p => p.ResponseTime);
            double avgTAT = processedResults.Average(p => p.TurnaroundTime);

            // Tính Throughput (Thông năng = n / Tổng thời gian hoàn thành cuối cùng)
            int maxCompletionTime = processedResults.Max(p => p.CompletionTime);
            double throughput = (double)processedResults.Count / maxCompletionTime;

            // Hiển thị lên Label
            lblAvgWT.Text = $"{avgWT:F2}";
            lblAvgRT.Text = $"{avgRT:F2}";
            lblAvgTAT.Text = $"{avgTAT:F2}";
            lblThroughput.Text = $"{throughput:F2}";
        }

        private void DrawGanttChart()
        {
            Graphics g = pnlGantt.CreateGraphics();
            g.Clear(pnlGantt.BackColor); // Xóa hình cũ

            if (ganttChartData == null || ganttChartData.Count == 0) return;

            int xOffset = 50;  // Vị trí bắt đầu vẽ theo chiều ngang
            int yOffset = 20;  // Vị trí bắt đầu vẽ theo chiều dọc
            int cellWidth = 40; // Độ rộng của mỗi đơn vị thời gian (có thể điều chỉnh)
            int cellHeight = 40;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            Pen pen = new Pen(Color.Black, 2);

            for (int i = 0; i < ganttChartData.Count; i++)
            {
                var item = ganttChartData[i];
                int width = (item.End - item.Start) * cellWidth;
                Rectangle rect = new Rectangle(xOffset, yOffset, width, cellHeight);

                // Vẽ hình chữ nhật cho tiến trình
                g.DrawRectangle(pen, rect);

                // Tô màu (Idle thì màu xám, còn lại màu xanh nhạt)
                Brush brush = (item.ProcessId == "Idle") ? Brushes.LightGray : Brushes.LightYellow;
                g.FillRectangle(brush, rect);

                // Vẽ Tên tiến trình (ID) chính giữa
                g.DrawString(item.ProcessId, font, Brushes.Black, xOffset + (width / 4), yOffset + 10);

                // Vẽ mốc thời gian bắt đầu
                g.DrawString(item.Start.ToString(), font, Brushes.Red, xOffset - 5, yOffset + cellHeight + 5);

                xOffset += width;

                // Nếu là phần tử cuối cùng, vẽ thêm mốc thời gian kết thúc
                if (i == ganttChartData.Count - 1)
                {
                    g.DrawString(item.End.ToString(), font, Brushes.Red, xOffset - 5, yOffset + cellHeight + 5);
                }
            }
        }

        bool CheckDataGridView()
        {
            // Biến để đánh dấu dữ liệu có hợp lệ hay không
            bool valid = true;
            string errorNotification = "";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // Bỏ qua dòng trống cuối cùng (nếu có)
                if (row.IsNewRow)
                {
                    continue;
                }
                // Lấy giá trị từ các ô (Cell)
                var valArrival = row.Cells["colArrival"].Value;
                var valBurst = row.Cells["colBurst"].Value;

                // 1. Kiểm tra xem có ô nào bị để trống không
                if (valArrival == null || valBurst == null || string.IsNullOrWhiteSpace(valArrival.ToString()) || string.IsNullOrWhiteSpace(valBurst.ToString()))
                {
                    valid = false;
                    errorNotification = $"Dòng {row.Index + 1} đang bị để trống dữ liệu.";
                    break;
                }

                // 2. Kiểm tra dữ liệu nhập vào có phải là số nguyên không
                bool isArrivalNumber = int.TryParse(valArrival.ToString(), out int arrivalTime);
                bool isBurstNumber = int.TryParse(valBurst.ToString(), out int burstTime);

                if (!isArrivalNumber || !isBurstNumber)
                {
                    valid = false;
                    errorNotification = $"Dòng {row.Index + 1} chứa ký tự không phải là số.";
                    break;
                }

                // 3. Kiểm tra logic giá trị (Ví dụ: Thời gian không được âm)
                if (arrivalTime < 0 || burstTime <= 0)
                {
                    valid = false;
                    errorNotification = $"Dòng {row.Index + 1}: Arrival Time phải >= 0 và Burst Time phải > 0.";
                    break;
                }
            }

            if (valid)
            {
                return true;
            }
            else
            {
                MessageBox.Show(errorNotification, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
