using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    // Lớp điều phối Round Robin, kế thừa từ Scheduler
    // Mỗi tiến trình được chạy tối đa 'quantumTime' tick rồi nhường CPU cho tiến trình kế tiếp
    public class RoundRobinScheduler : Scheduler
    {
        private int quantumTime; // Thời lượng tối đa mỗi tiến trình được chiếm CPU (time slice)

        // Constructor: nhận danh sách tiến trình và quantumTime, truyền processes lên lớp cha
        public RoundRobinScheduler(List<Process> processes, int quantumTime) : base(processes)
        {
            this.quantumTime = quantumTime;// Lưu quantumTime để sử dụng trong thuật toán
        }

        public override void Run()
        {
            int n = process.Count;    // Tổng số tiến trình cần lên lịch
            int currentTime = 0;      // Đồng hồ CPU, tăng từng tick
            int completed = 0;        // Đếm số tiến trình đã hoàn thành

            Queue<Process> readyQueue = new Queue<Process>(); // hàng đợi FIFO chứa các tiến trình sẵn sàng
            bool[] inQueue = new bool[n];                     // đánh dấu đã nạp vào queue chưa, tránh nạp trùng

            while (completed < n)
            {
                // nạp các tiến trình đã đến vào queue
                for (int i = 0; i < n; i++)
                    if (!inQueue[i] && process[i].arrivalTime <= currentTime)
                    {
                        readyQueue.Enqueue(process[i]); // thêm vào cuối queue
                        inQueue[i] = true;
                    }

                if (readyQueue.Count == 0) // không có tiến trình nào sẵn sàng → CPU idle
                {
                    appendGantt("IDLE", currentTime);
                    currentTime++;
                    continue;
                }

                Process current = readyQueue.Dequeue();      // lấy tiến trình đầu queue
                current.markResponse(currentTime);           // ghi nhận lần đầu tiên được CPU

                int runTime = Math.Min(quantumTime, current.remainingTime); // chạy tối đa quantum, hoặc ít hơn nếu sắp xong

                for (int tick = 0; tick < runTime; tick++)
                {
                    appendGantt(current.ID!, currentTime);   // ghi vào biểu đồ Gantt
                    current.executeOneTick();                // giảm remainingTime đi 1
                    currentTime++;

                    // nạp tiến trình mới đến ngay trong từng tick (không chờ hết quantum)
                    for (int i = 0; i < n; i++)
                        if (!inQueue[i] && process[i].arrivalTime <= currentTime)
                        {
                            readyQueue.Enqueue(process[i]);
                            inQueue[i] = true;
                        }
                }

                if (current.remainingTime == 0)
                {
                    completed++;
                    current.markCompletion(currentTime);     // ghi thời điểm kết thúc
                }
                else
                {
                    readyQueue.Enqueue(current);             // chưa xong → về cuối queue, chờ lượt tiếp
                }
            }
        }
    }
}