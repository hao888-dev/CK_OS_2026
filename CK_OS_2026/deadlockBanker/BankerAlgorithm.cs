using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.deadlockBanker;

namespace CK_OS_2026.deadlockBanker
{
    public class BankerAlgorithm
    {
        public BankerResult Run(BankerData data)
        {
            int p = data.ProcessCount;

            int r = data.ResourceCount;

            int[,] need = new int[p, r];

            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    need[i, j]
                        = data.Max[i, j]
                        - data.Allocation[i, j];
                }
            }

            int[] available = new int[r];

            for (int j = 0; j < r; j++)
            {
                int sum = 0;

                for (int i = 0; i < p; i++)
                {
                    sum += data.Allocation[i, j];
                }

                available[j]
                    = data.Instance[j] - sum;
            }

            bool[] finish = new bool[p];

            int[] order = new int[p];

            List<int[]> steps
                = new List<int[]>();

            steps.Add((int[])available.Clone());

            int step = 1;

            bool found;

            do
            {
                found = false;

                for (int i = 0; i < p; i++)
                {
                    if (!finish[i])
                    {
                        bool canRun = true;

                        for (int j = 0; j < r; j++)
                        {
                            if (need[i, j]
                                > available[j])
                            {
                                canRun = false;
                                break;
                            }
                        }

                        if (canRun)
                        {
                            for (int j = 0; j < r; j++)
                            {
                                available[j]
                                    += data.Allocation[i, j];
                            }

                            finish[i] = true;

                            order[i] = step;

                            step++;

                            steps.Add(
                                (int[])available.Clone()
                            );

                            found = true;
                        }
                    }
                }

            } while (found);

            List<string> safe
                = new List<string>();

            for (int s = 1; s < step; s++)
            {
                for (int i = 0; i < p; i++)
                {
                    if (order[i] == s)
                    {
                        safe.Add("P" + i);
                    }
                }
            }

            return new BankerResult()
            {
                Need = need,

                Available = available,

                AvailableSteps = steps,

                Order = order,

                SafeSequence = safe,

                IsSafe = safe.Count == p
            };
        }
    }
}
