using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class SRTFScheduler : Scheduler
    {
        // Thuộc tính để lưu trữ dữ liệu biểu đồ Gantt
        // Dùng class nhỏ để WinForms có thể lấy dữ liệu này vẽ giao diện
        public List<(string ProcessId, int Start, int End)> GanttData { get; private set; }

        public SRTFScheduler(List<Process> processes) : base(processes)
        {
            GanttData = new List<(string, int, int)>();
        }

        

        public override void Run()
        {
            int n = processes.Count;
            int completed = 0;
            int currentTime = 0;
            int shortest = -1;
            int minRemainingTime = int.MaxValue;
            bool found = false;

            // Để tính Response Time chính xác, ta cần biết tiến trình đã từng được chạy chưa
            // Ở đây dùng một Dictionary để đánh dấu
            Dictionary<string, bool> isStarted = processes.ToDictionary(p => p.Id, p => false);

            // Biến tạm để theo dõi việc gộp các khối trong Gantt Chart
            string? lastProcessId = null;
            int blockStartTime = 0;

            while (completed < n)
            {
                minRemainingTime = int.MaxValue;
                shortest = -1;
                found = false;

                // 1. Tìm tiến trình có RemainingTime nhỏ nhất tại thời điểm hiện tại
                for (int i = 0; i < n; i++)
                {
                    if (processes[i].ArrivalTime <= currentTime && processes[i].RemainingTime > 0 && processes[i].RemainingTime < minRemainingTime)
                    {
                        minRemainingTime = processes[i].RemainingTime;
                        shortest = i;
                        found = true;
                    }
                }

                // Xử lý trường hợp CPU rảnh (Idle)
                if (!found)
                {
                    if (lastProcessId != "Idle")
                    {
                        if (lastProcessId != null)
                        {
                            GanttData.Add((lastProcessId, blockStartTime, currentTime));
                        }     
                        
                        lastProcessId = "Idle";
                        blockStartTime = currentTime;
                    }
                    currentTime++;
                    continue;
                }

                // 2. Logic Gộp khối Gantt Chart: Nếu đổi tiến trình chạy thì lưu khối cũ lại
                if (processes[shortest].Id != lastProcessId)
                {
                    if (lastProcessId != null)
                    {
                        GanttData.Add((lastProcessId, blockStartTime, currentTime));
                    }
                    lastProcessId = processes[shortest].Id;
                    blockStartTime = currentTime;
                }

                // 3. Tính Response Time (chỉ tính lần đầu tiên CPU chạm vào tiến trình)
                if (!isStarted[processes[shortest].Id])
                {
                    processes[shortest].ResponseTime = currentTime - processes[shortest].ArrivalTime;
                    isStarted[processes[shortest].Id] = true;
                }

                // 4. Thực thi tiến trình trong 1 đơn vị thời gian
                processes[shortest].RemainingTime--;
                currentTime++;

                // 5. Kiểm tra hoàn thành
                if (processes[shortest].RemainingTime == 0)
                {
                    completed++;
                    processes[shortest].CompletionTime = currentTime;

                    // Gọi phương thức tính TAT và WT từ lớp cha
                    processes[shortest].CalculateTimes();
                }
            }

            // Lưu khối Gantt cuối cùng sau khi thoát vòng lặp
            if (lastProcessId != null)
            {
                GanttData.Add((lastProcessId, blockStartTime, currentTime));
            }
        }
    }
}

