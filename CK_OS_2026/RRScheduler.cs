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
            this.quantumTime = quantumTime;
        }

        public override void Run()
        {
            int n = process.Count;    // Tổng số tiến trình cần lên lịch
            int currentTime = 0;      // Đồng hồ CPU, tăng từng tick
            int completed = 0;        // Đếm số tiến trình đã hoàn thành
            int currentIndex = -1;    // Khởi đầu -1: lần đầu (i=1) → idx=0, tìm từ đầu danh sách

            // Vòng lặp chính: chạy đến khi tất cả tiến trình hoàn thành
            while (completed < n)
            {
                bool found = false; // Cờ: tìm được tiến trình để chạy chưa?

                // Tìm tiến trình tiếp theo theo kiểu vòng tròn (circular scan)
                // i=1: bỏ qua currentIndex hiện tại, bắt đầu tìm từ tiến trình KẾ TIẾP
                for (int i = 1; i <= n; i++)
                {
                    int idx = (currentIndex + i) % n; // Tính index vòng tròn, không bao giờ out of range

                    // Chọn tiến trình nếu: đã đến rồi VÀ chưa hoàn thành
                    if (process[idx].arrivalTime <= currentTime &&
                        process[idx].remainingTime > 0)
                    {
                        found = true;
                        currentIndex = idx; // Ghim tiến trình này vào CPU
                        break;
                    }
                }

                // Không có tiến trình nào sẵn sàng → CPU idle, tăng thời gian và thử lại
                if (!found)
                {
                    currentTime++;
                    continue;
                }

                // Ghi response time lần đầu tiên tiến trình được chạy
                // (bên trong markResponse tự kiểm tra, chỉ ghi 1 lần duy nhất)
                process[currentIndex].markResponse(currentTime);

                // Tính thời gian thực tế chạy: lấy min(quantumTime, remainingTime)
                // Tránh chạy quá thời gian còn lại của tiến trình
                int runTime = Math.Min(quantumTime, process[currentIndex].remainingTime);

                // Chạy từng tick để ghi chính xác từng ô trên biểu đồ Gantt
                for (int tick = 0; tick < runTime; tick++)
                {
                    appendGantt(process[currentIndex].ID!, currentTime); // Ghi ID vào Gantt tại tick này
                    process[currentIndex].executeOneTick();               // remainingTime -= 1
                    currentTime++;                                        // Tăng đồng hồ CPU
                }

                // Sau khi hết quantumTime, kiểm tra tiến trình có vừa hoàn thành không
                if (process[currentIndex].remainingTime == 0)
                {
                    completed++;                                       // Tăng bộ đếm hoàn thành
                    process[currentIndex].markCompletion(currentTime); // Lưu thời điểm kết thúc (tính TAT, WT)
                }

                // KHÔNG reset currentIndex → vòng sau tìm từ currentIndex+1
                // Đảm bảo đúng thứ tự Round Robin, tiến trình vừa chạy xếp cuối hàng chờ
            }
        }
    }
}