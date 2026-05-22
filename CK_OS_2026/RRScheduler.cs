using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public class RoundRobinScheduler : Scheduler
    {
        private int quantum;

        public RoundRobinScheduler(List<Process> processes, int quantum) : base(processes)
        {
            this.quantum = quantum;
        }

        public override void Run()
        {
            int n = process.Count;
            int currentTime = 0;
            int completed = 0;
            int currentIndex = -1; // Bắt đầu từ -1 để lần đầu tìm từ index 0

            while (completed < n)
            {
                bool found = false;
                for (int i = 1; i <= n; i++) // Bắt đầu từ i=1 để tìm từ NEXT index
                {
                    int idx = (currentIndex + i) % n;
                    if (process[idx].arrivalTime <= currentTime &&
                        process[idx].remainingTime > 0)
                    {
                        found = true;
                        currentIndex = idx;
                        break;
                    }
                }

                // Không có tiến trình nào sẵn sàng → CPU rảnh
                if (!found)
                {
                    currentTime++;
                    continue;
                }

                process[currentIndex].markResponse(currentTime); // Ghi thời điểm chạy lần đầu

                // Chạy tối đa quantum tick
                int runTime = Math.Min(quantum, process[currentIndex].remainingTime);
                for (int tick = 0; tick < runTime; tick++)
                {
                    appendGantt(process[currentIndex].ID!, currentTime);
                    process[currentIndex].executeOneTick();
                    currentTime++;
                }

                if (process[currentIndex].remainingTime == 0) // Tiến trình hoàn thành
                {
                    completed++;
                    process[currentIndex].markCompletion(currentTime);
                }
                // currentIndex giữ nguyên → vòng sau tự tìm từ currentIndex + 1
            }
        }
    }
}