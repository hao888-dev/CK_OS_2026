using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeSRTF
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
