using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.PageReplacement;

namespace CK_OS_2026.PageReplacement
{
    public class ClockAlgorithm : PageReplacementAlgorithm
    {
        public ClockAlgorithm(List<int> pages, int frameCount) : base(pages, frameCount) { }

        public override PageReplacementResult Run()
        {
            int n = Pages.Count;
            string[,] grid = InitializeGrid(n);
            string[] statusRow = new string[n];
            int pageFaults = 0;

            List<int> currentFrames = new List<int>();
            List<bool> useBit = new List<bool>();
            int pointer = 0;

            for (int step = 0; step < n; step++)
            {
                int page = Pages[step];
                statusRow[step] = "";

                // IndexOf để kiểm tra Hit 
                int hitIndex = currentFrames.IndexOf(page);

                if (hitIndex != -1)
                {
                    // HIT: Chỉ cần bật useBit lên true (Cơ hội thứ 2)
                    useBit[hitIndex] = true;
                }
                else
                {
                    // MISS
                    if (currentFrames.Count < FrameCount)
                    {
                        // Mảng chưa đầy -> Nạp ngay vào cuối, bỏ qua F
                        currentFrames.Add(page);
                        useBit.Add(true);
                        pointer = (pointer + 1) % FrameCount; // Cập nhật con trỏ
                    }
                    else
                    {
                        // Mảng đã đầy -> Đánh F và chạy vòng lặp tìm trang để thay thế
                        statusRow[step] = "F";
                        pageFaults++;

                        while (true)
                        {
                            if (useBit[pointer] == false)
                            {
                                // Tìm thấy trang có useBit == false -> Thay thế
                                currentFrames[pointer] = page;
                                useBit[pointer] = true;
                                pointer = (pointer + 1) % FrameCount;
                                break;
                            }
                            else
                            {
                                // Trang có useBit == true -> Reset về false và cho cơ hội 2, đi tiếp
                                useBit[pointer] = false;
                                pointer = (pointer + 1) % FrameCount;
                            }
                        }
                    }
                }

                // Ghi dữ liệu vào grid để hiển thị
                for (int i = 0; i < FrameCount; i++)
                {
                    string cellValue = "";

                    // Nếu Frame đã có dữ liệu
                    if (i < currentFrames.Count)
                    {
                        cellValue = currentFrames[i].ToString();
                        if (useBit[i])
                        {
                            cellValue += "*";
                        }
                    }

                    if (i == pointer)
                    {
                        cellValue = "-> " + cellValue;
                    }

                    grid[i, step] = cellValue;
                }
            }

            return new PageReplacementResult(Pages, FrameCount, grid, statusRow, pageFaults);
        }
    }
}
