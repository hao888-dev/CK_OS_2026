using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.PageReplacement;

namespace CK_OS_2026.PageReplacement
{
    public abstract class PageReplacementAlgorithm
    {
        protected List<int> Pages { get; private set; }
        protected int FrameCount { get; private set; }

        protected PageReplacementAlgorithm(List<int> pages, int frameCount)
        {
            Pages = new List<int>(pages);
            FrameCount = frameCount;
        }

        // Hàm trừu tượng
        public abstract PageReplacementResult Run();

        // Tạo Grid mặc định
        protected string[,] InitializeGrid(int n)
        {
            string[,] grid = new string[FrameCount, n];
            for (int i = 0; i < FrameCount; i++)
                for (int j = 0; j < n; j++)
                    grid[i, j] = "";
            return grid;
        }
    }
}
