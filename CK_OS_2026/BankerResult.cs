using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
{
    public class BankerResult
    {
        public int[,] Need { get; set; } = new int[0, 0];
        public int[] Available { get; set; } = Array.Empty<int>();
        public List<int[]> AvailableSteps { get; set; } = new List<int[]>();
        public int[] Order { get; set; } = Array.Empty<int>();
        public List<string> SafeSequence { get; set; } = new List<string>();
        public bool IsSafe { get; set; }
    }
}
