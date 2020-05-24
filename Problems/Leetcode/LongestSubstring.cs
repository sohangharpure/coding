using System;
using System.Collections.Generic;
using System.Text;


//https://leetcode.com/problems/longest-substring-without-repeating-characters/
namespace Problems.Leetcode
{
    class LSSolution
    {
        /*public static void Main(string[] args)
        {
            LSSolution solution = new LSSolution();
            Console.WriteLine(solution.LengthOfLongestSubstring("pwwkew"));
            Console.Read();
        }*/

        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 0)
                return 0;
            Dictionary<char, int> seenUnseen = new Dictionary<char, int>();
            var start = 0;
            var res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (seenUnseen.ContainsKey(s[i]))
                {
                    start = Math.Max(start, seenUnseen[s[i]] + 1);
                    seenUnseen[s[i]] = i;
                }
                else
                    seenUnseen.Add(s[i], i);

                res = Math.Max(res, i - start + 1);
            }

            return res;
        }
    }

    
}
