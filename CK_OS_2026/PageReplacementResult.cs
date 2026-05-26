using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class PageReplacementResult
    {
        public List<int> Pages { get; private set; }
        public int FramesCount { get; private set; }
        public string[,] Grid { get; private set; }
        public string[] StatusRow { get; private set; }
        public int PageFaults { get; private set; }

        // Constructor 
        public PageReplacementResult(List<int> pages, int framesCount, string[,] grid, string[] statusRow, int pageFaults)
        {
            Pages = new List<int>(pages);
            FramesCount = framesCount;
            // vì string và mảng là kiểu tham chiếu, nên cần clone để tránh side-effect từ bên ngoài
            Grid = (string[,])grid.Clone();
            StatusRow = (string[])statusRow.Clone();

            PageFaults = pageFaults;
        }
    }
}
