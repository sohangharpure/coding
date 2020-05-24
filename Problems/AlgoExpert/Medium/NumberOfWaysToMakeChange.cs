using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Medium
{

    public class Program
    {
        public static int NumberOfWaysToMakeChange(int n, int[] denoms)
        {
            //O(nd) time | O(n) space
            int[] ways = new int[n + 1];
            ways[0] = 1;
            foreach(int denom in denoms)
            {
                for (int amount = 1; amount < n + 1; amount ++)
                {
                    if (denom <= amount)
                        ways[amount] += ways[amount - denom];
                }
            }
            return ways[n];
        }
    }
}

//Sample Input: 6, [1,5]
//Sample Output: 2 (1 x 1 + 1 x 5  and 1 x 6)
