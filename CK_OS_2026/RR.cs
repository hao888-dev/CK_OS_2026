using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public partial class RR : Form
    {
        private RoundRobinScheduler? scheduler;

        public RR()
        {
            InitializeComponent();
        }

        // ── Nút "Xác nhận" – tạo các dòng trong bảng nhập ───────────────────
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRowCount.Text, out int rows) && rows > 0)
            {
                if (rows > 100)
                {
                    MessageBox.Show("Số lượng tiến trình phải nằm trong khoảng từ 1 đến 100!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRowCount.Clear();
                    txtRowCount.Focus();
                    return;
                }

                dgvData.Rows.Clear();
                for (int i = 1; i <= rows; i++)
                    dgvData.Rows.Add("P" + i, 0, 0);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Thông báo");
                txtRowCount.Clear();
                txtRowCount.Focus();
            }
        }

        // ── Nút "Lập lịch" – chạy Round Robin và hiển thị kết quả ──────────
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var dataRows = dgvData.Rows.Cast<DataGridViewRow>()
                                       .Where(r => !r.IsNewRow).ToList();

            if (dataRows.Count == 0)
            {
                MessageBox.Show("Bạn phải tạo và nhập dữ liệu trước khi lập lịch!",
                    "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRowCount.Focus();
                return;
            }

            if (!int.TryParse(txtQuantum.Text, out int quantum) || quantum <= 0)
            {
                MessageBox.Show("Vui lòng nhập Quantum Time hợp lệ (số nguyên dương > 0)!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantum.Focus();
                return;
            }

            if (!CheckDataGridView()) return;

            List<Process> inputProcesses = dgvData.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new Process(
                    row.Cells[0].Value?.ToString() ?? "Unknown",
                    Convert.ToInt32(row.Cells["colArrival"].Value),
                    Convert.ToInt32(row.Cells["colBurst"].Value)
                )).ToList();

            scheduler = new RoundRobinScheduler(inputProcesses, quantum);
            scheduler.Run();

            DisplayResults();
            GanttRenderer.Draw(pnlGantt, pictureBoxGantt, scheduler.ganttData);
        }

        // ── Hiển thị bảng kết quả + stats ────────────────────────────────────
        private void DisplayResults()
        {
            dgvResults.Rows.Clear();
            dgvResults.Visible = true;

            scheduler!.process.ForEach(p =>
                dgvResults.Rows.Add(p.ID!, p.waitingTime, p.responseTime, p.turnAroundTime));

            double avgWT = scheduler.process.Average(p => p.waitingTime);
            double avgRT = scheduler.process.Average(p => p.responseTime);
            double avgTAT = scheduler.process.Average(p => p.turnAroundTime);
            int maxCT = scheduler.process.Max(p => p.completionTime);
            double tp = (double)scheduler.process.Count / maxCT;

            lblAvgWT.Text = $"{avgWT:F2}";
            lblAvgRT.Text = $"{avgRT:F2}";
            lblAvgTAT.Text = $"{avgTAT:F2}";
            lblThroughput.Text = $"{tp:F2}";
        }

        // ── Kiểm tra dữ liệu nhập ────────────────────────────────────────────
        private bool CheckDataGridView()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;

                var valAT = row.Cells["colArrival"].Value;
                var valBT = row.Cells["colBurst"].Value;

                if (valAT == null || valBT == null ||
                    string.IsNullOrWhiteSpace(valAT.ToString()) ||
                    string.IsNullOrWhiteSpace(valBT.ToString()))
                {
                    ShowError($"Dòng {row.Index + 1} đang bị để trống dữ liệu.");
                    return false;
                }

                if (!int.TryParse(valAT.ToString(), out int at) ||
                    !int.TryParse(valBT.ToString(), out int bt))
                {
                    ShowError($"Dòng {row.Index + 1} chứa ký tự không phải là số.");
                    return false;
                }

                if (at < 0 || bt <= 0)
                {
                    ShowError($"Dòng {row.Index + 1}: Arrival Time >= 0 và Burst Time > 0.");
                    return false;
                }
            }
            return true;
        }

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}