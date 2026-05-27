using System;
using System.Collections.Generic;

namespace CK_OS_2026
{
    public class OPTResult
    {
        public List<int> Pages { get; set; } = new List<int>();
        public int FramesCount { get; set; }
        public int[,] Grid { get; set; } // mảng 2 chiều [,] -> ví dụ: new int[3,6] thì sẽ là Grid[0,2]
        public bool[] IsHit { get; set; } // true thi hit, false thì miss
        public bool[] IsReplacement { get; set; } // true thì sẽ thay trang
        public int PageFaults { get; set; } // đếm số lần page fault

        /*
            Pages = [7,0,1,2,0,3]

            FramesCount = 3

            Grid =
            7 7 7 2 2 2
            - 0 0 0 0 0
            - - 1 1 1 3

            IsHit =
            false false false false true false

            IsReplacement =
            false false false true false true

            PageFaults = 5
        */
    }

    internal class OPTAlgorithm
    {
        public static OPTResult RunOPT(List<int> pages, int frameCount)
        {
            int n = pages.Count;

            // Tạo object mới và gán thuộc tính
            OPTResult result = new OPTResult
            {
                Pages = pages,
                FramesCount = frameCount,
                Grid = new int[frameCount, n],
                IsHit = new bool[n],
                IsReplacement = new bool[n], 
                PageFaults = 0
            };

            // khởi tạo ban đầu -1 hết
            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Grid[i, j] = -1;
                }
            }

            List<int> currentFrames = new List<int>(); // lưu các trang hiện tại nằm trong bộ nhớ

            for (int i = 0; i < n; i++) // mỗi vòng xử lý một trang
            {
                int currentPage = pages[i]; // lấy trang hiện tại
                bool isHit = currentFrames.Contains(currentPage); // kiểm tra xem có trong frame hay chưa
                result.IsHit[i] = isHit; // ghi nhận lại có thì true, không thì false;

                if (!isHit) // nếu không có trong frame
                {
                    result.PageFaults++; // tăng lỗi trang

                    if (currentFrames.Count < frameCount) // nếu frame còn chỗ
                    {
                        currentFrames.Add(currentPage); // thì thêm vào bình thường
                        result.IsReplacement[i] = false; // chỉ thêm không thay nên IsReplacement vẫn false
                    }
                    else // nếu frame đầy
                    {
                        result.IsReplacement[i] = true; // là sẽ thay trang để hiển thị chữ F

                        int replaceIndex = -1; // khởi tạo ví trí sẽ thay
                        int farthestIndex = -1; // trang nào sẽ xa nhất

                        for (int j = 0; j < currentFrames.Count; j++) // duyệt từng frame trong currentFrame 
                        {
                            int nextUse = int.MaxValue; // giả định là không dùng nữa 

                            for (int k = i + 1; k < n; k++) // nhìn về tương lai
                            {
                                if (pages[k] == currentFrames[j]) // nếu thấy trang đó xuất hiện lại trong tương lai
                                {
                                    nextUse = k; // thấy là lưu
                                    break; //// ngắt vì chỉ cần thấy trong tương là dừng để xét
                                }
                            }

                            if (nextUse > farthestIndex) // tìm thằng xa nhất
                            {
                                farthestIndex = nextUse;
                                replaceIndex = j;
                            }
                        }

                        currentFrames[replaceIndex] = currentPage; // sau khi tìm xong ứng viên tốt nhất để thay thì lưu lại
                    }
                    // nếu trang đang xét tới có trong frame rồi thì skip vì isHit = true
                }

                for (int f = 0; f < currentFrames.Count; f++) // in ra danh sách lên mành hình hiển thị
                {
                    result.Grid[f, i] = currentFrames[f];
                }
            }

            return result;
        }
    }
}