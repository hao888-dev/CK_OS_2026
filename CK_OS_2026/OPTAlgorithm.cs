using System;
using System.Collections.Generic;

namespace CK_OS_2026
{
    public class OPTResult // lưu kết quả cho giao diện
    {
        public List<int> Pages { get; set; } = new List<int>(); // danh sách các trang
        public int FramesCount { get; set; } // số lượng frame => biết cần bao nhiêu dòng để vẽ bảng
        public int[,] Grid { get; set; } // Grid[dòng frame, cột bước]
        /*
            Pages:
            7 0 1 2

            Frame: 3

            Step	7	0	1	2
            F1	    7	7	7	2
            F2		    0	0	0
            F3			    1	1

            Grid[0,0] = 7
            Grid[0,1] = 7
            Grid[0,2] = 7
            Grid[0,3] = 2
        */
        public bool[] IsHit { get; set; }  // [false, false, false, true, false] 
        /*
            | Page   | 7 | 0 | 1 | 0 |
            | ------ | - | - | - | - |
            | Result | F | F | F | H |
        */
        public int PageFaults { get; set; } // đếm số lần thiếu trang
    }

    internal class OPTAlgorithm // chứa thuật toán OTP
    {
        public static OPTResult RunOPT(List<int> pages, int frameCount)
        {
            int n = pages.Count;
            OPTResult result = new OPTResult
            {
                Pages = pages,
                FramesCount = frameCount,
                Grid = new int[frameCount, n], // frame dòng, n cột
                IsHit = new bool[n], // n cột
                PageFaults = 0
            };

            for (int i = 0; i < frameCount; i++) // duyệt từng dòng frame
            {
                for (int j = 0; j < n; j++) // duyệt từng cột (từng page)
                {
                    result.Grid[i, j] = -1; // gán cho -1 => khởi tạo ban đầu trống hết
                }
            }

            List<int> currentFrames = new List<int>(); 

            for (int i = 0; i < n; i++) // duyệt từng page
            {
                int currentPage = pages[i]; // lấy page hiện tại
                bool isHit = currentFrames.Contains(currentPage); // kiểm tra có trong frame chưa, có trả về true, không thì false
                result.IsHit[i] = isHit; // lưu lại true hoặc false vào mảng để tí in ra

                if (!isHit) // trường hợp true
                {
                    result.PageFaults++;

                    if (currentFrames.Count < frameCount) // nếu số frame hiện tại vẫn còn nhỏ hơn số frame được cấp
                    {
                        currentFrames.Add(currentPage); // nạp vào
                    }
                    else
                    {
                        int replaceIndex = -1; // vị trí cần thay
                        int farthestIndex = i; // vị trí xa nhất

                        for (int j = 0; j < currentFrames.Count; j++) // duyệt từng frame
                        {
                            int nextUse = int.MaxValue; // ban đầu cho luôn vị trí 2 triệu

                            for (int k = i + 1; k < n; k++) // đi tìm trong tương lai xa 
                            {
                                if (pages[k] == currentFrames[j]) // tìm thấy
                                {
                                    nextUse = k; // lưu lại ví trí
                                    break; // tìm thấy lần gần nhất xuất hiện rồi => dừng
                                }
                            }

                            if (nextUse > farthestIndex) // so sánh để tìm thằng xa nhất
                            {
                                farthestIndex = nextUse; // lưu lại thằng xa nhất hiện tại để xét vòng sau
                                replaceIndex = j; // lại vị trí sẽ thay (nếu không còn ai xa hơn)
                            }
                        }

                        currentFrames[replaceIndex] = currentPage; // thay
                    }
                }

                for (int f = 0; f < currentFrames.Count; f++) // duyệt từng frame
                {
                    result.Grid[f, i] = currentFrames[f]; // ghi vào Grid
                }
            }

            return result; // trả về toàn bộ kết quả cho giao diện
        }
    }
}