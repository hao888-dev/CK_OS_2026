using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public class SJFScheduler : Scheduler
    {
        public SJFScheduler(List<Process> processes) : base(processes)
        {

        }

        // Non-Preemptive SJF

        public override void Run()
        {
            int n = process.Count;
            int currentTime = 0;
            int completed = 0;
            int lockedIndex = -1; // -1 = không có tiến trình nào đang chạy

            while (completed < n) // Lặp đến khi tất cả tiến trình hoàn thành
            {
                if (lockedIndex == -1) // Chỉ chọn tiến trình mới khi CPU rảnh
                {
                    int shortest = -1;

                    for (int i = 0; i < n; i++)
                    {
                        if (process[i].arrivalTime <= currentTime && // Đã đến
                            process[i].remainingTime > 0)            // Chưa xong
                        {
                            if (shortest == -1 ||
                                process[i].burstTime < process[shortest].burstTime || // Burst ngắn hơn
                                (process[i].burstTime == process[shortest].burstTime &&
                                 process[i].arrivalTime < process[shortest].arrivalTime)) // Đến sớm hơn nếu bằng burst
                            {
                                shortest = i;
                            }
                        }
                    }

                    if (shortest == -1)
                    {
                        currentTime++; // CPU rảnh, không có tiến trình nào sẵn sàng
                        continue;
                    }

                    lockedIndex = shortest;
                    process[lockedIndex].markResponse(currentTime); // Ghi thời điểm bắt đầu chạy
                }

                appendGantt(process[lockedIndex].ID!, currentTime); // Cập nhật Gantt
                process[lockedIndex].executeOneTick();              // Chạy 1 đơn vị thời gian
                currentTime++;

                if (process[lockedIndex].remainingTime == 0) // Tiến trình hoàn thành
                {
                    completed++;
                    process[lockedIndex].markCompletion(currentTime); // Ghi thời điểm kết thúc
                    lockedIndex = -1; // Mở khóa CPU
                }
            }
        }
    }
}
