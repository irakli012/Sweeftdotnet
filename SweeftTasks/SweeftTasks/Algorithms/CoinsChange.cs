using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Algorithms
{
    public static class CoinsChange
    {
        public static int MinSplit(int amount)
        {
            if (amount <= 0) return 0;

            int[] coins = { 50, 20, 10, 5, 1 };
            int count = 0;
            int i = 0;

            while (amount > 0 && i < coins.Length)
            {
                if (amount >= coins[i])
                {
                    amount -= coins[i];
                    count++;
                }
                else
                {
                    i++;
                }
            }

            return count;
        }
    }
}
