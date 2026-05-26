public class LRUResult
{
    public List<int> Pages { get; set; } = new List<int>();
    public int FramesCount { get; set; }
    public int[,] Grid { get; set; }
    public bool[] IsHit { get; set; }
    public bool[] IsReplacement { get; set; } 
    public int PageFaults { get; set; }
}

internal class LRUAlgorithm
{
    public static LRUResult RunLRU(List<int> pages, int frameCount)
    {
        int n = pages.Count;
        LRUResult result = new LRUResult
        {
            Pages = pages,
            FramesCount = frameCount,
            Grid = new int[frameCount, n],
            IsHit = new bool[n],
            IsReplacement = new bool[n], 
            PageFaults = 0
        };

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result.Grid[i, j] = -1;
            }
        }

        List<int> currentFrames = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int currentPage = pages[i];
            bool isHit = currentFrames.Contains(currentPage);
            result.IsHit[i] = isHit;

            if (!isHit)
            {
                result.PageFaults++;

                if (currentFrames.Count < frameCount)
                {
                    currentFrames.Add(currentPage);
                    result.IsReplacement[i] = false; 
                }
                else
                {
                    result.IsReplacement[i] = true; 

                    int replaceIndex = -1;
                    int farthestIndex = i;

                    for (int j = 0; j < currentFrames.Count; j++)
                    {
                        int lastUse = -1;

                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (pages[k] == currentFrames[j])
                            {
                                lastUse = k;
                                break;
                            }
                        }

                        if (lastUse < farthestIndex)
                        {
                            farthestIndex = lastUse;
                            replaceIndex = j;
                        }
                    }

                    currentFrames[replaceIndex] = currentPage;
                }
            }

            for (int f = 0; f < currentFrames.Count; f++)
            {
                result.Grid[f, i] = currentFrames[f];
            }
        }

        return result;
    }
}