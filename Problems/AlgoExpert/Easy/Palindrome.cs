using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    //https://www.algoexpert.io/questions/Palindrome%20Check
    public class PalindromeSolution
    {
        //O(n) time, O(1) space
        public static bool IsPalindrome(string str)
        {
            // Write your code here.
            if (String.IsNullOrWhiteSpace(str))
                return false;
            int i = 0, j = str.Length - 1, mid;
            mid = str.Length % 2 == 0 ? str.Length / 2 : (str.Length / 2) + 1;
            while (i <= mid && j >= mid)
            {
                if (str[i] != str[j])
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
