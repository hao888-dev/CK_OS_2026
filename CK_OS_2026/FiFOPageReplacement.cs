using System;
using System.Collections.Generic;

namespace CK_OS_2026
{
    public class FIFOResult // lưu kết quả cho giao diện
    {
        public List<int> Pages { get; set; } = new List<int>(); // danh sách các trang
        public int FramesCount { get; set; } // số lượng frame => biết cần bao nhiêu dòng để vẽ bảng
        public int[,] Grid { get; set; } // Grid[dòng frame, cột bước]
        public bool[] IsHit { get; set; }  // true = HIT, false = FAULT
        public int PageFaults { get; set; } // đếm số lần thiếu trang
    }

    internal class FIFOAlgorithm // chứa thuật toán FIFO
    {
        public static FIFOResult RunFIFO(List<int> pages, int frameCount)
        {
            int n = pages.Count;
            FIFOResult result = new FIFOResult
            {
                Pages = pages,
                FramesCount = frameCount,
                Grid = new int[frameCount, n],
                IsHit = new bool[n],
                PageFaults = 0
            };

            // Khởi tạo Grid toàn -1 (ô trống)
            for (int i = 0; i < frameCount; i++)
                for (int j = 0; j < n; j++)
                    result.Grid[i, j] = -1;

            List<int> currentFrames = new List<int>(); // các trang đang trong frame
            int pointer = 0; // con trỏ trỏ vào vị trí frame sẽ bị thay tiếp theo (vòng tròn)

            for (int i = 0; i < n; i++) // duyệt từng page
            {
                int currentPage = pages[i]; // lấy page hiện tại
                bool isHit = currentFrames.Contains(currentPage); // kiểm tra có trong frame chưa
                result.IsHit[i] = isHit; // lưu lại kết quả hit/fault

                if (!isHit) // PAGE FAULT
                {
                    result.PageFaults++;

                    if (currentFrames.Count < frameCount) // còn chỗ trống
                    {
                        currentFrames.Add(currentPage); // nạp vào frame
                    }
                    else // frame đầy => thay trang tại vị trí pointer (vào sớm nhất)
                    {
                        currentFrames[pointer] = currentPage; // thay thế trang tại vị trí con trỏ
                    }

                    pointer = (pointer + 1) % frameCount; // dịch con trỏ sang vị trí kế tiếp (vòng tròn)
                }

                // Ghi trạng thái frame hiện tại vào Grid
                for (int f = 0; f < currentFrames.Count; f++)
                    result.Grid[f, i] = currentFrames[f];
            }

            return result; // trả về toàn bộ kết quả cho giao diện
        }
    }
}