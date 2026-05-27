using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    // Lớp điều phối SJF (Shortest Job First) - Non-Preemptive
    // Chọn tiến trình có burst time ngắn nhất để chạy, không bị ngắt giữa chừng
    public class SJFScheduler : Scheduler
    {
        // Constructor: truyền danh sách tiến trình lên lớp cha
        public SJFScheduler(List<Process> processes) : base(processes)
        {

        }

        // Non-Preemptive SJF: một khi đã chọn tiến trình, chạy đến khi xong mới chọn cái mới
        public override void Run()
        {
            int n = process.Count;    // Tổng số tiến trình
            int currentTime = 0;      // Đồng hồ CPU
            int completed = 0;        // Số tiến trình đã hoàn thành
            int lockedIndex = -1;     // Index tiến trình đang chiếm CPU (-1 = CPU đang rảnh)

            // Vòng lặp chính: chạy đến khi tất cả hoàn thành
            while (completed < n)
            {
                // Chỉ chọn tiến trình mới khi CPU đang rảnh (lockedIndex == -1)
                // Non-Preemptive: nếu đang chạy thì KHÔNG được chọn lại
                if (lockedIndex == -1)
                {
                    int shortest = -1; // Index tiến trình có burst ngắn nhất tìm được

                    // Duyệt tất cả tiến trình để tìm cái phù hợp nhất
                    for (int i = 0; i < n; i++)
                    {
                        if (process[i].arrivalTime <= currentTime && // Tiến trình đã đến
                            process[i].remainingTime > 0)            // Tiến trình chưa hoàn thành
                        {
                            if (shortest == -1 ||
                                process[i].burstTime < process[shortest].burstTime || // Burst ngắn hơn → ưu tiên hơn
                                (process[i].burstTime == process[shortest].burstTime &&
                                 process[i].arrivalTime < process[shortest].arrivalTime)) // Burst bằng nhau → chọn đến sớm hơn
                            {
                                shortest = i;
                            }
                        }
                    }

                    // Không có tiến trình nào sẵn sàng → CPU idle, tăng thời gian và thử lại
                    if (shortest == -1)
                    {
                        appendGantt("IDLE", currentTime);
                        currentTime++;
                        continue;
                    }

                    // Khóa CPU vào tiến trình vừa chọn, sẽ giữ đến khi tiến trình xong
                    lockedIndex = shortest;

                    // Ghi nhận thời điểm bắt đầu chạy lần đầu (response time)
                    process[lockedIndex].markResponse(currentTime);
                }

                // Ghi ID tiến trình vào biểu đồ Gantt tại tick hiện tại
                appendGantt(process[lockedIndex].ID!, currentTime);

                // Chạy tiến trình 1 tick: remainingTime -= 1
                process[lockedIndex].executeOneTick();
                currentTime++;

                // Kiểm tra tiến trình có vừa hoàn thành không
                if (process[lockedIndex].remainingTime == 0)
                {
                    completed++;                                          // Tăng bộ đếm
                    process[lockedIndex].markCompletion(currentTime);     // Lưu thời điểm kết thúc (tính TAT, WT)
                    lockedIndex = -1;                                     // Mở khóa CPU, sẵn sàng chọn tiến trình mới
                }
            }
        }
    }
}