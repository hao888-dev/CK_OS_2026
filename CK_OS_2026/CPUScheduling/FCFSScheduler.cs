using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.CPUScheduling;

namespace CK_OS_2026.CPUScheduling
{
    public class FCFSScheduler : Scheduler
    {
        public FCFSScheduler(List<Process> processes)
            : base(processes)
        {

        }

        public override void Run()
        {
            int currentTime = 0;

            List<Process> sortedProcesses = process
                .OrderBy(p => p.arrivalTime)
                .ThenBy(p => p.ID)
                .ToList();

            //*fix thời gian rảnh giữa các tiến trình
            foreach (Process p in sortedProcesses)
            {
                while (currentTime < p.arrivalTime)
                {
                    appendGantt("IDLE", currentTime);
                    currentTime++;
                }

                p.markResponse(currentTime);

                while (p.remainingTime > 0)
                {
                    appendGantt(p.ID!, currentTime);

                    p.executeOneTick();

                    currentTime++;
                }

                p.markCompletion(currentTime);
            }
        }
    }
}