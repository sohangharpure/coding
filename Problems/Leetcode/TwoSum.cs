using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Leetcode
{

    //https://leetcode.com/problems/two-sum/
    public class TwoSumSolution
    {
        /*public static void Main(string[] args)
        {
            TwoSumSolution solution = new TwoSumSolution();

            solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        }*/


        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 0)
                return null;

            Dictionary<int, int> seenUnseen = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];

                if (seenUnseen.ContainsKey(diff))
                    return new[] { seenUnseen[diff], i };
                else
                     if (!seenUnseen.ContainsKey(nums[i]))
                    seenUnseen.Add(nums[i], i);
            }

            return null;
        }
    }
}
