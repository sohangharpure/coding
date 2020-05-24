using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    //https://www.algoexpert.io/questions/Insertion%20Sort
    //Worst case = O(n^2), O(1) space

    //Assuming the 0th element is always sorted(this is the sorted array)
    //Starting from the 1st element upto n, try inserting the element 
    //into the "already" sorted array. If element is lesser, swap
    public class InsertionSortSolution
    {
        public static int[] InsertionSort(int[] array)
        {
            if (array == null || array.Length == 0)
                return new int[0] { };

            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap(j, j - 1, array);
                    j -= 1;
                }
            }
            return array;
        }

        public static void Swap(int i, int j, int[] array)
        {
            int temp;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }            
    }
}
