using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class PriorityScheduler : Scheduler // đổi internal thành public để dễ hơn nhé
    {
        // constructor
        public PriorityScheduler(List<Process> processes) : base(processes)
        {

        }

        public override void Run() // code thuật ở trong hàm này nhé
        {
            int currentTime = 0;
            int completedProcesses = 0;
            int n = processes.Count;

            while (completedProcesses < n) // lặp cho đến khi tất cả tiến trình hoàn thành
            {
                Process currentProcess = null; // tạo biến để lưu tiến trình hiện tại

                foreach (Process p in processes) // duyệt qua tất cả các tiến trình
                {
                    if (p.ArrivalTime <= currentTime && p.RemainingTime > 0) // nếu tiến trình đã đến và chưa hoàn thành
                    {
                        if (currentProcess == null)
                        {
                            currentProcess = p; // nếu chưa có tiến trình nào được chọn, chọn tiến trình hiện tại

                        }

                        else if (p.Priority < currentProcess.Priority)
                        { // nếu tiến trình hiện tại có độ ưu tiên cao hơn
                            currentProcess = p;

                        }

                        else if (p.Priority == currentProcess.Priority) // nếu độ ưu tiên bằng nhau, chọn tiến trình có thời gian đến sớm hơn
                        {
                            if (p.ArrivalTime < currentProcess.ArrivalTime)
                            {
                                currentProcess = p;
                            }
                        }
                    }
                }


                if (currentProcess == null)
                {
                    currentTime++;
                    continue;
                }

                currentProcess.ResponseTime = currentTime - currentProcess.ArrivalTime;
                currentTime += currentProcess.BurstTime;
                currentProcess.CompletionTime = currentTime;
                currentProcess.RemainingTime = 0;
                currentProcess.CalculateTimes();
                completedProcesses++;

                /*
                    Priority Non-Preemptive Scheduling

                    Rule:
                    - Process có priority nhỏ hơn sẽ được ưu tiên cao hơn
                    - CPU sẽ chạy process tới hết rồi mới chuyển process khác

                    Steps:

                    1. Tìm process:
                        - đã tới
                        - chưa hoàn thành
                        - có priority cao nhất

                    2. Nếu chưa có process nào tới:
                        currentTime++

                    3. Chạy process tới khi hoàn thành

                    4. Cập nhật:
                        - Response Time: thời gian từ lúc process tới đến lúc được CPU chạy lần đầu

                        - Completion Time: thời điểm process hoàn thành

                        - Waiting Time: tổng thời gian process chờ CPU

                        - Turnaround Time:tổng thời gian process ở trong hệ thống (Completion Time - Arrival Time)
                */
            }
        }
    }
}
