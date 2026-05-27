using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.deadlockBanker;

namespace CK_OS_2026.deadlockBanker
{
    public class BankerData
    {
        public int ProcessCount { get; set; }
        public int ResourceCount { get; set; }
        public int[] Instance { get; set; } = Array.Empty<int>();
        public int[,] Allocation { get; set; } = new int[0, 0];
        public int[,] Max { get; set; } = new int[0, 0];
    }
}
