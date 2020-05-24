using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Leetcode
{
    //https://leetcode.com/problems/reverse-integer/
    class ReverseIntegerSolution
    {
        /*public static void Main(string[] args)
        {
            Console.WriteLine(Reverse(359));
        }*/

        public static int Reverse(int x)
        {
            if (x >= Int32.MaxValue || x <= Int32.MinValue || x == 0)
                return 0;

            int sign = x / Math.Abs(x);
            var abs = string.Concat(Math.Abs(x).ToString().Reverse());

            int result = 0;

            Int32.TryParse(abs, out result);

            return result * sign;
        }
    }
}
