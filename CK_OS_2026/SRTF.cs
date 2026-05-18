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

        // ========================= Tạo bảng =========================

        private void CreateBang()
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
            CreateBang();
        }

        private void txtRowCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateBang();
                e.SuppressKeyPress = true;
            }
        }

        // ========================= Xác nhận & chạy thuật toán =========================

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
                return;

            // Chuyển đổi dữ liệu từ DataGridView thành danh sách Process
            List<Process> inputProcesses = dgvData.Rows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new Process(
                    row.Cells[0].Value?.ToString() ?? "Unknown",
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

        // ========================= Hiển thị kết quả =========================

        private void DisplayResults()
        {
            dgvResults.Rows.Clear();
            dgvResults.Visible = true;

            processedResults.ForEach(p =>
            {
                dgvResults.Rows.Add(p.Id, p.WaitingTime, p.ResponseTime, p.TurnaroundTime);
            });

            double avgWT = processedResults.Average(p => p.WaitingTime);
            double avgRT = processedResults.Average(p => p.ResponseTime);
            double avgTAT = processedResults.Average(p => p.TurnaroundTime);

            // Throughput = số tiến trình / thời điểm hoàn thành cuối cùng
            int maxCompletionTime = processedResults.Max(p => p.CompletionTime);
            double throughput = (double)processedResults.Count / maxCompletionTime;

            lblAvgWT.Text = $"{avgWT:F2}";
            lblAvgRT.Text = $"{avgRT:F2}";
            lblAvgTAT.Text = $"{avgTAT:F2}";
            lblThroughput.Text = $"{throughput:F2}";
        }

        // ========================= Vẽ Gantt Chart =========================

        private void DrawGanttChart()
        {
            Graphics g = pnlGantt.CreateGraphics();
            g.Clear(pnlGantt.BackColor);

            if (ganttChartData == null || ganttChartData.Count == 0) return;

            int xOffset = 50;
            int yOffset = 20;
            int cellWidth = 40;
            int cellHeight = 40;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            Pen pen = new Pen(Color.Black, 2);

            for (int i = 0; i < ganttChartData.Count; i++)
            {
                var item = ganttChartData[i];
                int width = (item.End - item.Start) * cellWidth;
                Rectangle rect = new Rectangle(xOffset, yOffset, width, cellHeight);

                // Tô màu (Idle thì màu xám, còn lại màu vàng nhạt)
                Brush brush = (item.ProcessId == "Idle") ? Brushes.LightGray : Brushes.LightYellow;
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);

                // Tên tiến trình căn giữa ô
                g.DrawString(item.ProcessId, font, Brushes.Black, xOffset + (width / 4), yOffset + 10);

                // Mốc thời gian bắt đầu
                g.DrawString(item.Start.ToString(), font, Brushes.Red, xOffset - 5, yOffset + cellHeight + 5);

                xOffset += width;

                // Mốc thời gian kết thúc (chỉ vẽ ở phần tử cuối)
                if (i == ganttChartData.Count - 1)
                {
                    g.DrawString(item.End.ToString(), font, Brushes.Red, xOffset - 5, yOffset + cellHeight + 5);
                }
            }
        }

        // ========================= Kiểm tra dữ liệu =========================

        private bool CheckDataGridView()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;

                var valArrival = row.Cells["colArrival"].Value;
                var valBurst = row.Cells["colBurst"].Value;

                // 1. Kiểm tra ô trống
                if (valArrival == null || valBurst == null ||
                    string.IsNullOrWhiteSpace(valArrival.ToString()) ||
                    string.IsNullOrWhiteSpace(valBurst.ToString()))
                {
                    ShowError($"Dòng {row.Index + 1} đang bị để trống dữ liệu.");
                    return false;
                }

                // 2. Kiểm tra kiểu số nguyên
                if (!int.TryParse(valArrival.ToString(), out int arrivalTime) ||
                    !int.TryParse(valBurst.ToString(), out int burstTime))
                {
                    ShowError($"Dòng {row.Index + 1} chứa ký tự không phải là số.");
                    return false;
                }

                // 3. Kiểm tra giá trị hợp lệ
                if (arrivalTime < 0 || burstTime <= 0)
                {
                    ShowError($"Dòng {row.Index + 1}: Arrival Time phải >= 0 và Burst Time phải > 0.");
                    return false;
                }
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}