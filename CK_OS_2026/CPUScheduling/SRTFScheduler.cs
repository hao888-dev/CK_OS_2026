using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.CPUScheduling;

namespace CK_OS_2026.CPUScheduling
{
    public class SRTFScheduler : Scheduler
    {

        public SRTFScheduler(List<Process> processes) : base(processes) { }

        public override void Run()
        {
            int n = process.Count;
            int currentTime = 0;
            int completed = 0;

            while (completed < n)
            {

                int shortest = -1;

                for (int i = 0; i < n; i++)
                {
                    if (process[i].arrivalTime <= currentTime &&
                        process[i].remainingTime > 0)
                    {
                        if (shortest == -1 ||
                            process[i].remainingTime < process[shortest].remainingTime)
                        {
                            shortest = i;
                        }
                    }
                }

                if (shortest == -1)
                {
                    appendGantt("IDLE", currentTime);

                    currentTime++;
                    continue;
                }

                string? currentProcessId = process[shortest].ID;

                appendGantt(process[shortest].ID!, currentTime);

                if (process[shortest].remainingTime == process[shortest].burstTime)
                {
                    process[shortest].markResponse(currentTime);
                }

                process[shortest].executeOneTick();
                currentTime++;

                if (process[shortest].remainingTime == 0)
                {
                    completed++;
                    process[shortest].markCompletion(currentTime);
                }
            }
        }

    }
}
