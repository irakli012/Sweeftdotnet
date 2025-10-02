using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Algorithms
{
    public static class StairVariants
    {
        public static int CountVariants(int stairCount)
        {
            if (stairCount <= 0) return 0;
            if (stairCount == 1) return 1;
            if (stairCount == 2) return 2;

            int stepone = 1, steptwo = 2, result = 0;

            for (int i = 3; i <= stairCount; i++)
            {
                result = stepone + steptwo;
                stepone = steptwo;
                steptwo = result;
            }

            return result;
        }
    }
}
