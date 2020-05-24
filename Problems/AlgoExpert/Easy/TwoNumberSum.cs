using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    //https://www.algoexpert.io/questions/Two%20Number%20Sum

    public class TwoNumberSumSolution
    {
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            //This method(Array.Sort) uses the introspective sort(introsort) algorithm as follows:
            //If the partition size is fewer than 16 elements, it uses an insertion sort algorithm.
            //If the number of partitions exceeds 2 * LogN, where N is the range of the input array, it uses a Heapsort algorithm.
            //Otherwise, it uses a Quicksort algorithm.
            Array.Sort(array);
            for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0;)
            {
                int currentSum = array[i] + array[j];
                if (currentSum == targetSum)
                    return new int[] { array[i], array[j] };
                else if (currentSum < targetSum)
                    i++;
                else if (currentSum > targetSum)
                    j--;
            }
            return new int[0] { };
        }
    }
}
