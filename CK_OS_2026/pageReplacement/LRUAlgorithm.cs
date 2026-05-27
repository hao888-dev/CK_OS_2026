using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.PageReplacement;

namespace CK_OS_2026.PageReplacement
{
    public class LRUAlgorithm : PageReplacementAlgorithm
    {
        public LRUAlgorithm(List<int> pages, int frameCount) : base(pages, frameCount) { }
        public override PageReplacementResult Run()
        {
            int n = Pages.Count;
            string[,] grid = InitializeGrid(n);
            string[] statusRow = new string[n];
            int pageFaults = 0;

            List<int> currentFrames = new List<int>();
            List<int> lastUsed = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currentPage = Pages[i];
                statusRow[i] = "";

                // Dùng IndexOf để tìm vị trí của trang trong khung
                int hitIndex = currentFrames.IndexOf(currentPage);

                if (hitIndex != -1)
                {
                    // HIT: Đã có trong khung -> Chỉ cần cập nhật lại thời gian sử dụng
                    lastUsed[hitIndex] = i;
                }
                else
                {
                    // MISS: Không có trong khung
                    if (currentFrames.Count < FrameCount)
                    {
                        // Khung chưa đầy -> Nạp trực tiếp vào cuối List, bỏ qua đánh F
                        currentFrames.Add(currentPage);
                        lastUsed.Add(i); // Lưu lại thời gian tương ứng
                    }
                    else
                    {
                        // Khung đã đầy -> Tìm trang cũ nhất để thay -> Đánh F
                        statusRow[i] = "F";
                        pageFaults++;

                        int minTime = int.MaxValue;
                        int replaceIndex = -1;

                        // Duyệt qua List để tìm vị trí có thời gian sử dụng lâu nhất (minTime)
                        for (int f = 0; f < currentFrames.Count; f++)
                        {
                            if (lastUsed[f] < minTime)
                            {
                                minTime = lastUsed[f];
                                replaceIndex = f;
                            }
                        }

                        // Thay thế trang và cập nhật thời gian ở vị trí tương ứng
                        currentFrames[replaceIndex] = currentPage;
                        lastUsed[replaceIndex] = i;
                    }
                }

                for (int f = 0; f < currentFrames.Count; f++)
                {
                    grid[f, i] = currentFrames[f].ToString();
                }
            }

            return new PageReplacementResult(Pages, FrameCount, grid, statusRow, pageFaults);
        }
    }
}
