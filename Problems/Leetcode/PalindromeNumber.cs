using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Leetcode
{
    //https://leetcode.com/problems/palindrome-number/
    public class PalindromeNumberSolution
    {
        /*public static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome(-121));
        }*/

        public static bool IsPalindrome(int x)
        {
            int originalNumber = x, result = 0;
            if (x >= Int32.MaxValue || x <= Int32.MinValue)
                return false;
            if (x == 0)
                return true;
            int sign = x / Math.Abs(x);
            if (sign < 0)
                return false;
            while (x != 0)
            {
                result = (result * 10) + x % 10;
                if (result >= Int32.MaxValue || result <= Int32.MinValue || result == 0)
                    return false;
                x /= 10;
            }

            if (result >= Int32.MaxValue || result <= Int32.MinValue || result == 0)
                return false;

            if (result == originalNumber)
                return true;
            else
                return false;
        }
    }
}
