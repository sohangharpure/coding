using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Leetcode
{
    //https://leetcode.com/problems/longest-common-prefix/
    class LongestCommonPrefixSolution
    {

        /*public static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix(new string[] {"flower", "flow", "flight" }));
        }*/

        public static string LongestCommonPrefix(string[] strs)
        {

            if (strs.Length <= 0)
                return String.Empty;

            StringBuilder result = new StringBuilder();

            var firstString = strs[0];
            bool flag = false;

            if (strs.Length == 1)
                return strs[0];


            for (int i = 0; i < firstString.Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i < strs[j].Length && strs[j][i] == firstString[i])
                    {
                        flag = true;
                        continue;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result.Append(firstString[i]);
                    flag = false;
                }
                else
                    break;
            }

            return result.ToString();

        }
    }
}
