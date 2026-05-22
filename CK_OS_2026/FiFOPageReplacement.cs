using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeSRTF;

namespace CK_OS_2026
{
    public class FIFOPageReplacement : Scheduler
    {
        private int[] pages;
        private int frameCount;

        public FIFOPageReplacement(List<Process> processes, int[] pages, int frameCount) : base(processes)
        {
            this.pages = pages;
            this.frameCount = frameCount;
        }

        public override void Run()
        {
            int[] frames = new int[frameCount];
            int pageFaults = 0;
            int fifoIndex = 0; // Con trỏ xoay vòng, trỏ vào frame cũ nhất

            // Khởi tạo frames rỗng = -1
            for (int i = 0; i < frameCount; i++)
                frames[i] = -1;

            for (int i = 0; i < pages.Length; i++)
            {
                int page = pages[i];
                bool found = false;

                // Kiểm tra page có trong frames chưa
                for (int j = 0; j < frameCount; j++)
                {
                    if (frames[j] == page)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) // Page trống
                {
                    pageFaults++;
                    frames[fifoIndex] = page;                     // Thay thế frame cũ nhất
                    fifoIndex = (fifoIndex + 1) % frameCount;     // Xoay vòng sang frame kế
                }

                appendGantt(page.ToString(), i); // Ghi nhận bước xử lý trang
            }
        }
    }
}