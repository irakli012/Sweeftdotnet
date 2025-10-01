using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Algorithms
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            int i = 0;
            int j = text.Length - 1;

            while (i < j)
            {
                if (text[i] != text[j])
                {
                    return false;
                }
                i++;
                j--;
            }

            return true;
        }
    }
}