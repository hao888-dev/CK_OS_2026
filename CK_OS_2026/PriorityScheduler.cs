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

        // Non-Preemptive 
        public override void Run()
        {
            int currentTime = 0; // thời gian hiện tại
            int completedProcesses = 0; // số tiến trình đã xong
            int n = process.Count; // tổng số tiến trình

            while (completedProcesses < n) // lặp đến khi tất cả process được hoàn thành
            {
                int targetIndex = -1; // biến lưu tiến trình được chọn để chạy => chưa chọn process nào 

                for (int i = 0; i < n; i++) // duyệt toàn bộ process để tìm process sẽ được chạy
                {
                    if (process[i].arrivalTime <= currentTime && process[i].remainingTime > 0) // là arrivalTime đã đến (bé hơn currentTime) và chưa chạy xong (remainingTime lớn hơn 0)
                    {
                        if (targetIndex == -1) // nếu chưa có ai được chọn, chọn luôn process đầu (trường hợp hay gặp của P1)
                        {
                            targetIndex = i; // chọn
                        }

                        else if (process[i].priority < process[targetIndex].priority) // chọn process có priority thấp hơn
                        {
                            targetIndex = i;
                        }

                        // nếu độ ưu tiên bằng nhau, chọn tiến trình có thời gian đến sớm hơn
                        else if (process[i].priority == process[targetIndex].priority)
                        {
                            if (process[i].arrivalTime < process[targetIndex].arrivalTime)
                            {
                                targetIndex = i;
                            }
                        }
                    }
                }

                // không có process nào tới => cpu nghỉ
                if (targetIndex == -1) // tất là P1 có arrivalTime là 5 => 0 - 4 cpu không có gì để chạy
                {
                    currentTime++;
                    continue;
                }

                Process currentProcess = process[targetIndex]; // lấy process được chọn

                if (currentProcess.remainingTime == currentProcess.burstTime) // Response Time = First Start Time − Arrival Time (vô lúc 5s nhưng 8s mới được chạy => chờ cho lần đầu được chạy là 3s)
                {
                    currentProcess.markResponse(currentTime); // remainingTime = burstTime => process chưa từng chạy lần nào => currentTime khi đó sẽ là response time của process đang được xét
                }

                while (currentProcess.remainingTime > 0) // chạy cho hết
                {
                    appendGantt(currentProcess.ID!, currentTime); // ghi vào gantt

                    currentProcess.executeOneTick(); 
                    currentTime++;
                }

                currentProcess.markCompletion(currentTime); // lưu lại thời điểm hoàn thành của process ấy

                completedProcesses++; // +1 khi 1 process hoàn thành 
            }
        }
    }
    
}
