using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public class PriorityScheduler : Scheduler
    {
        private bool isPreemptive;

        // Thêm cờ isPreemptive vào Constructor
        public PriorityScheduler(List<Process> processes, bool isPreemptive) : base(processes)
        {
            this.isPreemptive = isPreemptive;
        }

        public override void Run()
        {
            int currentTime = 0;
            int completedProcesses = 0;
            int n = process.Count;

            while (completedProcesses < n)
            {
                int targetIndex = -1;

                // Duyệt tìm Process ưu tiên cao nhất trong số các tiến trình ĐÃ ĐẾN và CHƯA XONG
                for (int i = 0; i < n; i++)
                {
                    if (process[i].arrivalTime <= currentTime && process[i].remainingTime > 0)
                    {
                        if (targetIndex == -1)
                        {
                            targetIndex = i;
                        }
                        else if (process[i].priority < process[targetIndex].priority)
                        {
                            targetIndex = i;
                        }
                        else if (process[i].priority == process[targetIndex].priority)
                        {
                            if (process[i].arrivalTime < process[targetIndex].arrivalTime)
                            {
                                targetIndex = i;
                            }
                        }
                    }
                }

                // Không có tiến trình nào khả dụng => CPU nhàn rỗi
                if (targetIndex == -1)
                {
                    currentTime++;
                    continue;
                }

                Process currentProcess = process[targetIndex];

                // Đánh dấu thời gian đáp ứng (Response Time) ở lần chạy ĐẦU TIÊN
                if (currentProcess.remainingTime == currentProcess.burstTime)
                {
                    currentProcess.markResponse(currentTime);
                }

                // --- XỬ LÝ DỰA VÀO CHẾ ĐỘ NGƯỜI DÙNG CHỌN ---
                if (isPreemptive)
                {
                    // Chế độ Preemptive (Cắt ngang): Chạy 1 tick rồi vòng lên đánh giá lại xem có tiến trình khác chen ngang không
                    appendGantt(currentProcess.ID!, currentTime);
                    currentProcess.executeOneTick();
                    currentTime++;

                    if (currentProcess.remainingTime == 0)
                    {
                        currentProcess.markCompletion(currentTime);
                        completedProcesses++;
                    }
                }
                else
                {
                    // Chế độ Non-Preemptive (Độc quyền): Chạy một mạch cho đến khi remainingTime = 0
                    while (currentProcess.remainingTime > 0)
                    {
                        appendGantt(currentProcess.ID!, currentTime);
                        currentProcess.executeOneTick();
                        currentTime++;
                    }
                    currentProcess.markCompletion(currentTime);
                    completedProcesses++;
                }
            }
        }
    }
}