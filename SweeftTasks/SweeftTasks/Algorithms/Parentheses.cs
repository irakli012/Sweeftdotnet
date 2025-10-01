using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Algorithms
{
    public static class Parentheses
    {
        public static bool IsProperly(string sequence)
        {
            int ParenthesisCount = 0;

            foreach (char c in sequence)
            {
                if (c == '(') ParenthesisCount++;

                else if (c == ')')
                {
                    ParenthesisCount--;
                    if (ParenthesisCount < 0)
                    {
                        return false;
                    }
                }
            }

            return ParenthesisCount == 0;
        }
    }
}
