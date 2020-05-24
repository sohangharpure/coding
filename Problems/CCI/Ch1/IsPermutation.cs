using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.CCI.Ch1
{
    class IsPermutation
    {
        /*public static void Main(string[] args)
        {
            Console.WriteLine(IsPermutationBySorting(Console.ReadLine().Trim(), Console.ReadLine().Trim().ToString()).ToString());
        }*/

        public static bool IsPermutationBySorting(string input1, string input2)
        {
            if (input1.Length != input2.Length)
                return false;

            char[] ordered1 = input1.OrderBy(alphabet => alphabet).ToArray();
            char[] ordered2 = input2.OrderBy(alphabet => alphabet).ToArray();
            return ordered1.SequenceEqual(ordered2);
        }
    }
}
