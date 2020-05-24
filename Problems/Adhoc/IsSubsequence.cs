using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Adhoc
{
    public class IsSubsequence
    {
        public static bool IsStringSubsequence(string s1, string s2, int l1, int l2)
        {
            if (l1 == 0)
                return true;

            if (l2 == 0)
                return false;

            if (s1[l1 - 1] == s2[l2 - 1])
                return IsStringSubsequence(s1, s2, l1 - 1, l2 - 1);

            return IsStringSubsequence(s1, s2, l1, l2 - 1);
        }

        public static bool IsStringSubsequenceIterative(string str1, string str2, int m, int n)
        {
            int j = 0;

            // Traverse str2 and str1, and compare 
            // current character of str2 with first 
            // unmatched char of str1, if matched  
            // then move ahead in str1 
            for (int i = 0; i < n && j < m; i++)
                if (str1[j] == str2[i])
                    j++;

            // If all characters of str1 were found 
            // in str2 
            return (j == m);
        }

        /*public static void Main(string[] args)
        {
            string s1 = "abcd";
            string s2 = "abegfcd";
            //string s2_modified = new string(s2.OrderBy(x => x).ToArray());
            //Console.WriteLine(IsStringSubsequence(s1, s2_modified, s1.Length, s2_modified.Length));
            Console.WriteLine(IsStringSubsequenceIterative(s1, s2, s1.Length, s2.Length));
        }*/
    }
}
