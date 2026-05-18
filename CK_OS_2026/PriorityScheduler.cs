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
        public PriorityScheduler(List<Process> processes) : base(processes)
        {       
        }
        // Non-Preemptive Priority
        public override void Run()
        {
            int currentTime = 0;
            int completedProcesses = 0;
            int n = process.Count;

            while (completedProcesses < n)
            {
                int targetIndex = -1; // tạo biến để lưu tiến trình hiện tại

                for (int i = 0; i < n; i++)
                {
                    if (process[i].arrivalTime <= currentTime && process[i].remainingTime > 0)
                    {
                        if (targetIndex == -1)
                        {
                            targetIndex = i;
                        }
                        // Số Priority nhỏ hơn nghĩa là độ ưu tiên cao hơn
                        else if (process[i].priority < process[targetIndex].priority)
                        {
                            targetIndex = i;
                        }
                        // Nếu độ ưu tiên bằng nhau, chọn tiến trình có thời gian đến sớm hơn
                        else if (process[i].priority == process[targetIndex].priority)
                        {
                            if (process[i].arrivalTime < process[targetIndex].arrivalTime)
                            {
                                targetIndex = i;
                            }
                        }
                    }
                }
                // bỏ qua vụ idle (thời gian nghỉ của CPU)
                if (targetIndex == -1)
                {
                    currentTime++;
                    continue;
                }

                // Respone Time 
                Process currentProcess = process[targetIndex];

                if (currentProcess.remainingTime == currentProcess.burstTime)
                {
                    currentProcess.markResponse(currentTime);
                }

                // Vẽ gantt + chạy độc quyền
                while (currentProcess.remainingTime > 0)
                {
                    appendGantt(currentProcess.ID!, currentTime);

                    currentProcess.executeOneTick();
                    currentTime++;
                }

                // Tính và tăng hoàn thành Process
                currentProcess.markCompletion(currentTime);
                completedProcesses++;
            }
        }
    }
    
}
