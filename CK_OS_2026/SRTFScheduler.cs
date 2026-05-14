using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class SRTFScheduler : Scheduler
    {
        // Dữ liệu để vẽ Gantt Chart
        public List<(string ProcessId, int Start, int End)> GanttData
        {
            get;
            private set;
        }

        public SRTFScheduler(List<Process> processes) : base(processes)
        {
            GanttData = new List<(string, int, int)>();
        }

        public override void Run()
        {
            int n = processes.Count;

            int currentTime = 0;
            int completed = 0;

            // Lưu tiến trình trước đó để gộp Gantt
            string lastProcessId = "";

            while (completed < n)
            {
                int shortest = -1;

                // =========================
                // 1. Tìm tiến trình ngắn nhất
                // =========================
                for (int i = 0; i < n; i++)
                {
                    if (processes[i].ArrivalTime <= currentTime &&
                        processes[i].RemainingTime > 0)
                    {
                        if (shortest == -1 ||
                            processes[i].RemainingTime <
                            processes[shortest].RemainingTime)
                        {
                            shortest = i;
                        }
                    }
                }

                // =========================
                // 2. CPU Idle
                // =========================
                if (shortest == -1)
                {
                    currentTime++;
                    continue;
                }

                string currentProcessId = processes[shortest].Id;

                // =========================
                // 3. Gantt Chart
                // =========================

                // Nếu đổi tiến trình
                if (GanttData.Count == 0 ||
                    lastProcessId != currentProcessId)
                {
                    GanttData.Add((
                        currentProcessId,
                        currentTime,
                        currentTime + 1
                    ));
                }
                else
                {
                    // Nếu vẫn là tiến trình cũ
                    var last = GanttData[GanttData.Count - 1];

                    GanttData[GanttData.Count - 1] = (
                        last.ProcessId,
                        last.Start,
                        last.End + 1
                    );
                }

                lastProcessId = currentProcessId;

                // =========================
                // 4. Response Time
                // =========================
                if (processes[shortest].RemainingTime ==
                    processes[shortest].BurstTime)
                {
                    processes[shortest].ResponseTime =
                        currentTime - processes[shortest].ArrivalTime;
                }

                // =========================
                // 5. Chạy tiến trình
                // =========================
                processes[shortest].RemainingTime--;

                currentTime++;

                // =========================
                // 6. Hoàn thành
                // =========================
                if (processes[shortest].RemainingTime == 0)
                {
                    completed++;

                    processes[shortest].CompletionTime =
                        currentTime;

                    processes[shortest].CalculateTimes();
                }
            }
        }
    }
}

