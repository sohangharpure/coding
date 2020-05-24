using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    //https://www.algoexpert.io/questions/Binary%20Search
    public class BinarySearchSolution
    {
        public static int BinarySearch(int[] array, int target)
        {
            // Write your code here.
            // return BinarySearchRecursive(array, target, 0, array.Length - 1);
            return BinarySearchIterative(array, target, 0, array.Length - 1);
        }

        //O(log(n) time, O(1) space
        public static int BinarySearchIterative(int[] array, int target, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (array[mid] == target)
                    return mid;
                else if (target < array[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return -1;
        }

        //O(log(n) time, O(log(n)) space
        public static int BinarySearchRecursive(int[] array, int target, int start, int end)
        {
            if (start > end)
                return -1;
            int mid = (start + end) / 2;
            if (array[mid] == target)
                return mid;
            else if (target < array[mid])
                return BinarySearchRecursive(array, target, start, mid - 1);
            else
                return BinarySearchRecursive(array, target, mid + 1, end);
        }
    }
}
