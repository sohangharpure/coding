using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Leetcode
{
    //https://leetcode.com/problems/sqrtx/
    public class SquareRootSolution
    {
        /*public static void Main(string[] args)
        {
            Console.WriteLine(floorSqrt(2147395600));
            Console.WriteLine(floorSqrt(-1));
            Console.WriteLine(floorSqrt(8));
            Console.WriteLine(floorSqrt(64));
        }*/

        public static int floorSqrt(int x)
        {
            if (x <= 0 || x == 1)
                return x;

            int i = 1, result = 1;

            //no need to go over x/2
            while (i <=x/2 && result <= x)
            {
                try
                {
                    i++;
                    result = checked(i * i);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    break;
                }
            }
            return i - 1;
        }
    }
}
