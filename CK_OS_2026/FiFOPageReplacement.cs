using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    // Lớp thay thế trang theo thuật toán FIFO (First In First Out)
    // Trang nào vào bộ nhớ trước sẽ bị thay thế trước
    public class FIFOPageReplacement : Scheduler
    {
        private int[] pages;      // Chuỗi các trang cần truy cập (page reference string)
        private int frameCount;   // Số khung trang (frame) có trong bộ nhớ vật lý

        // Constructor: nhận danh sách tiến trình, chuỗi trang, và số frame
        public FIFOPageReplacement(List<Process> processes, int[] pages, int frameCount) : base(processes)
        {
            this.pages = pages;
            this.frameCount = frameCount;
        }

        public override void Run()
        {
            int[] frames = new int[frameCount]; // Mảng lưu các trang đang ở trong bộ nhớ
            int pageFaults = 0;                 // Đếm tổng số lần page fault (truy cập bị trượt)
            int fifoIndex = 0;                  // Con trỏ xoay vòng, luôn trỏ vào frame vào sớm nhất (cũ nhất)

            // Khởi tạo tất cả frame = -1 (rỗng, chưa có trang nào)
            for (int i = 0; i < frameCount; i++)
                frames[i] = -1;

            // Duyệt qua từng trang trong chuỗi truy cập
            for (int i = 0; i < pages.Length; i++)
            {
                int page = pages[i]; // Trang cần truy cập ở bước này
                bool found = false;  // Cờ: trang có đang ở trong frame không?

                // Kiểm tra page hit: trang có sẵn trong bộ nhớ chưa?
                for (int j = 0; j < frameCount; j++)
                {
                    if (frames[j] == page)
                    {
                        found = true; // Page hit → không cần thay thế
                        break;
                    }
                }

                // Page fault: trang chưa có trong bộ nhớ → phải nạp vào
                if (!found)
                {
                    pageFaults++;                                    // Tăng bộ đếm page fault
                    frames[fifoIndex] = page;                        // Ghi đè lên frame cũ nhất (FIFO)
                    fifoIndex = (fifoIndex + 1) % frameCount;        // Dịch con trỏ sang frame kế tiếp (xoay vòng)
                }

                // Ghi nhận trạng thái trang tại bước i vào biểu đồ
                appendGantt(page.ToString(), i);
            }

            // Kết thúc: pageFaults chứa tổng số lần page fault của toàn bộ chuỗi
        }
    }
}