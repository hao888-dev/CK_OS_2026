using System;
using System.Collections.Generic;

namespace CK_OS_2026
{
    // Class dùng để chứa kết quả trả về cho giao diện
    public class OPTResult
    {
        public List<int> Pages { get; set; } = new List<int>();
        public int FramesCount { get; set; }
        public int[,] Grid { get; set; } // Lưới lưu trạng thái frame [Dòng frame, Cột bước]
        public bool[] IsHit { get; set; } // true: Hit (H), false: Fault (F)
        public int PageFaults { get; set; }
    }

    internal class OPTAlgorithm
    {
        public static OPTResult RunOPT(List<int> pages, int frameCount)
        {
            int n = pages.Count;
            OPTResult result = new OPTResult
            {
                Pages = pages,
                FramesCount = frameCount,
                Grid = new int[frameCount, n],
                IsHit = new bool[n],
                PageFaults = 0
            };

            // Khởi tạo lưới bằng -1 (thể hiện frame trống)
            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Grid[i, j] = -1;
                }
            }

            List<int> currentFrames = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currentPage = pages[i];
                bool isHit = currentFrames.Contains(currentPage);
                result.IsHit[i] = isHit;

                if (!isHit)
                {
                    result.PageFaults++;

                    // Nếu frame còn trống thì nạp vào
                    if (currentFrames.Count < frameCount)
                    {
                        currentFrames.Add(currentPage);
                    }
                    else
                    {
                        // THUẬT TOÁN OPT: Tìm trang sẽ lâu được dùng lại nhất trong tương lai
                        int replaceIndex = -1;
                        int farthestIndex = i;

                        for (int j = 0; j < currentFrames.Count; j++)
                        {
                            int nextUse = int.MaxValue; // Mặc định là không còn dùng nữa

                            // Tìm vị trí tiếp theo trang này xuất hiện
                            for (int k = i + 1; k < n; k++)
                            {
                                if (pages[k] == currentFrames[j])
                                {
                                    nextUse = k;
                                    break;
                                }
                            }

                            // Cập nhật vị trí xa nhất
                            if (nextUse > farthestIndex)
                            {
                                farthestIndex = nextUse;
                                replaceIndex = j;
                            }
                        }

                        // Thay thế trang
                        currentFrames[replaceIndex] = currentPage;
                    }
                }

                // Ghi nhận trạng thái của các frame vào lưới ở cột i
                for (int f = 0; f < currentFrames.Count; f++)
                {
                    result.Grid[f, i] = currentFrames[f];
                }
            }

            return result;
        }
    }
}