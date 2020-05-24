using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problems.AlgoExpert.Hard
{
    //https://leetcode.com/problems/trapping-rain-water/
    class WaterAreaSolution
    {
        //Time complexity = O(n)
        //Space complexity = O(n)
        public static int WaterArea(int[] heights)
        {
            //This will ultimately store how much water each index can hold
            int[] maxes = new int[heights.Length];

            int[] leftMaxes = new int[heights.Length];
            int[] rightMaxes = new int[heights.Length];

            int leftMax = 0, rightMax = 0;

            //Step 1
            //Now we first calculate what is the height of the tallest pillar to the 
            //left of the value in the given array from left to right(called leftMax)
            for(int i=0; i<heights.Length;i++)
            {
                //maxes[i] = leftMax;
                leftMaxes[i] = leftMax;
                leftMax = Math.Max(leftMax, heights[i]);
            }

            //Step 2
            //Now we calculate what is the height of the tallest pillar to the 
            //right of the value in the given array from right to left(called rightMax)
            for (int i=heights.Length-1; i>=0; i--)
            {
                rightMaxes[i] = rightMax;
                rightMax = Math.Max(rightMax, heights[i]);
            }

            //Step 3 calculates the actual water it can hold
            for(int i=0; i<heights.Length; i++)
            {
                int minHeight = Math.Min(leftMaxes[i], rightMaxes[i]);
                //There is room to store water
                if (heights[i] < minHeight)
                    maxes[i] = minHeight - heights[i];
                else
                    maxes[i] = 0;
            }

            return maxes.Sum();

            /*
             * Below is a solution which can be done via a single array

            //Step 2
            //Now we calculate, for each index, what is the height of the tallest pillar to the
            //right of the value in the given array. This is done in reverse.
            //maxes[i] already stores the leftMax. So the amount of water it will hold will be 
            //min of right and left maxes, and then check if the current index in the array has 
            //room to hold that much of water.
            //For e.g for the last index
            //leftMax = 10, rightMax = 0, current value = 3
            //3 < 10. Therefore, water = min(0,10)

            for (int i=heights.Length-1; i>=0; i--)
            {
                int minHeight = Math.Min(rightMax, maxes[i]);
                if (heights[i] < minHeight)
                    maxes[i] = minHeight - heights[i];
                else
                    maxes[i] = 0;
                rightMax = Math.Max(rightMax, heights[i]);
            }
            return maxes.Sum();

            */
        }

        /*public static void Main(string[] args)
        {
            //Console.WriteLine(WaterAreaSolution.WaterArea(new int[] { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 }));
            Console.WriteLine(WaterAreaSolution.WaterArea(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
            Console.ReadKey();
        }*/
    }   
}
