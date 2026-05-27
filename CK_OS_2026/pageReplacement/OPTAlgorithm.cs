using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.PageReplacement;

namespace CK_OS_2026.PageReplacement
{
    public class OPTAlgorithm : PageReplacementAlgorithm
    {
        public OPTAlgorithm(List<int> pages, int frameCount) : base(pages, frameCount) { }

        public override PageReplacementResult Run()
        {
            int n = Pages.Count;
            string[,] grid = InitializeGrid(n);
            string[] statusRow = new string[n];
            int pageFaults = 0;

            List<int> currentFrames = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currentPage = Pages[i];
                bool isHit = currentFrames.Contains(currentPage);
                statusRow[i] = ""; // Mặc định để trống

                if (!isHit)
                {
                    if (currentFrames.Count < FrameCount)
                    {
                        currentFrames.Add(currentPage); // Nạp vô chỗ trống, bỏ qua F
                    }
                    else
                    {
                        // Khung đã đầy, tiến hành thay thế -> Đánh F
                        statusRow[i] = "F";
                        pageFaults++;

                        int replaceIndex = -1;
                        int farthestIndex = i;

                        for (int j = 0; j < currentFrames.Count; j++)
                        {
                            int nextUse = int.MaxValue;
                            for (int k = i + 1; k < n; k++)
                            {
                                if (Pages[k] == currentFrames[j])
                                {
                                    nextUse = k;
                                    break;
                                }
                            }

                            if (nextUse > farthestIndex)
                            {
                                farthestIndex = nextUse;
                                replaceIndex = j;
                            }
                        }
                        currentFrames[replaceIndex] = currentPage;
                    }
                }

                for (int f = 0; f < currentFrames.Count; f++)
                    grid[f, i] = currentFrames[f].ToString();
            }

            return new PageReplacementResult(Pages, FrameCount, grid, statusRow, pageFaults);
        }
    }
}
