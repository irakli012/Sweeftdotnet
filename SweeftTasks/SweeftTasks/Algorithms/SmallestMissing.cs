using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Algorithms
{
    public static class SmallestMissing
    {
        public static int NotContains(int[] array)
        {
            var positiveNums = new HashSet<int>();

            foreach (int num in array)
            {
                if (num > 0 ) positiveNums.Add(num);
            }

            int neededNum = 1;

            while (positiveNums.Contains(neededNum))
            {
                neededNum++;
            }

            return neededNum;
        }
    }
}
