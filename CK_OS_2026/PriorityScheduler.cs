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
        private bool isPreemptive; // cờ để đánh dấu => true là Preemptive, false là Non-Preemptive

        public PriorityScheduler(List<Process> processes, bool isPreemptive) : base(processes) // base là gọi constructor của class cha Scheduler
        {
            this.isPreemptive = isPreemptive;
        }

        public override void Run()
        {
            int currentTime = 0; // thời gian hiện tại
            int completedProcesses = 0; // số process hoàn thành
            int n = process.Count; // tổng số process

            while (completedProcesses < n) // duyệt đến khi mọi process hoàn thành
            {
                int targetIndex = -1; // lưu vị trí của process được chọn

                for (int i = 0; i < n; i++) // duyệt qua hết các process để tìm chỉ 1 process là ứng viên tốt nhất để vào CPU chạy
                {
                    if (process[i].arrivalTime <= currentTime && process[i].remainingTime > 0) // đến rồi (vì bé hơn currentTime và remainingTime vẫn còn => được quyền vào chạy
                    {
                        if (targetIndex == -1) // lần đầu thấy process hợp lệ
                        {
                            targetIndex = i; // chọn tạm thời process đó
                        }
                        else if (process[i].priority < process[targetIndex].priority) // so sánh chỉ số priority của process thứ i hiện tại với priority của ứng viên vừa tìm được 
                        {
                            targetIndex = i; // nếu process thứ i tốt hơn thì cập nhật lại thứ i sẽ là ứng viên
                        }
                        else if (process[i].priority == process[targetIndex].priority) // bằng nhau về chỉ số priority thì xét đến arrivalTime
                        {
                            if (process[i].arrivalTime < process[targetIndex].arrivalTime) // ai arrivalTime bé hơn thì được chọn làm ứng viên
                            {
                                targetIndex = i;
                            }
                        }
                    }
                }

                if (targetIndex == -1) // không có ứng viên => CPU nhàn rỗi
                {
                    currentTime++; // tăng thời gian hiện tại lên xem để các process có thể đến
                    continue;
                }

                Process currentProcess = process[targetIndex]; // lấy process ứng viên tốt nhất để chọn vào chạy trong CPU


                // Response Time là thời gian chờ tính từ lúc vào đế khi được chạy lần đầu tiên
                if (currentProcess.remainingTime == currentProcess.burstTime) // nếu remainingTime còn bằng burstTime => process chưa chạy lần nào
                {
                    currentProcess.markResponse(currentTime); // vậy ta có điểm mốc là thời gian chạy lần đầu => responseTime = thời điểm được chạy lần đầu - arrivalTime
                }

                if (isPreemptive) // ý tưởng sẽ là chạy 1 tick rồi dừng, xong quay lại xét toàn bộ process để xem có process nào được ưu tiên hơn nữa không
                {
                    appendGantt(currentProcess.ID!, currentTime); // ghi vào gantt chart 1 tick 
                    currentProcess.executeOneTick(); // trừ đi 1 remainingTime
                    currentTime++; // tăng hiện tại lên

                    if (currentProcess.remainingTime == 0) // nếu hết remainingTime
                    {
                        currentProcess.markCompletion(currentTime); // vậy nó đã hoàn thành
                        completedProcesses++; // tăng số process đã hoàn thành
                    }
                }
                else
                {
                    while (currentProcess.remainingTime > 0) // cứ con remainingTime là chạy => chạy hết thì thôi
                    {
                        appendGantt(currentProcess.ID!, currentTime); // ghi vào gantt chart 1 tick 
                        currentProcess.executeOneTick(); // trừ đi 1 remainingTime
                        currentTime++; // tăng hiện tại lên
                    }
                    currentProcess.markCompletion(currentTime); // sau khi chạy hết xong thì cũng là lúc nó hoàn thành => ghi nhận lại
                    completedProcesses++; // tăng hiện tại lên
                }
            }
        }
    }
}