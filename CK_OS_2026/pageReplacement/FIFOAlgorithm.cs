using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.PageReplacement;

namespace CK_OS_2026.PageReplacement
{
    public class FIFOAlgorithm : PageReplacementAlgorithm
    {
        public FIFOAlgorithm(List<int> pages, int frameCount) : base(pages, frameCount) { }
        public override PageReplacementResult Run()
        {
            int n = Pages.Count;
            string[,] grid = InitializeGrid(n);
            string[] statusRow = new string[n];
            int pageFaults = 0;

            List<int> currentFrames = new List<int>();
            int pointer = 0;

            for (int i = 0; i < n; i++)
            {
                int currentPage = Pages[i];
                bool isHit = currentFrames.Contains(currentPage);
                statusRow[i] = "";

                if (!isHit)
                {
                    if (currentFrames.Count < FrameCount)
                    {
                        // Còn chỗ trống: Nạp vào, KHÔNG đánh F
                        currentFrames.Add(currentPage);
                    }
                    else
                    {
                        // Đã đầy: Phải thay thế -> Đánh F và đếm lỗi
                        currentFrames[pointer] = currentPage;
                        statusRow[i] = "F";
                        pageFaults++;
                    }
                    pointer = (pointer + 1) % FrameCount;
                }

                for (int f = 0; f < FrameCount; f++)
                {
                    string cellValue = "";

                    // Chỉ xử lý những Frame đã có trang nạp vào
                    if (f < currentFrames.Count)
                    {
                        cellValue = currentFrames[f].ToString();
                    }

                    grid[f, i] = cellValue;
                }
            }

            return new PageReplacementResult(Pages, FrameCount, grid, statusRow, pageFaults);
        }
    }
}
