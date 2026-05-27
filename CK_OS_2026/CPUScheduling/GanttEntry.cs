using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.CPUScheduling;

namespace CK_OS_2026.CPUScheduling
{
    public class GanttEntry
    {
        public string ProcessId { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }

        public GanttEntry(string processId, int start, int end)
        {
            ProcessId = processId;
            Start = start;
            End = end;
        }

        public void ExtendEnd() => End++;
    }
}
