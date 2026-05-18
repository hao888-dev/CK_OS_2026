using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeSRTF
{
    public abstract class Scheduler
    {
        protected List<Process> processes;
        public List<Process> process => processes;
        public List<GanttEntry> ganttData { get; protected set; }

        protected Scheduler(List<Process> processes)
        {
            this.processes = processes;
            ganttData = new List<GanttEntry>();
        }

        public abstract void Run();

        protected void appendGantt(string currId, int currTime)
        {
            if (ganttData.Count == 0 || currId != ganttData[^1].ProcessId)
            {
                ganttData.Add(new GanttEntry(currId, currTime, currTime + 1));
            }
            else
            {
                ganttData[^1].ExtendEnd();
            }

        }
    }
}
