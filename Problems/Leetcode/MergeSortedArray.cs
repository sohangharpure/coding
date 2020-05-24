using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Leetcode
{
    class MergeSortedArraySolution
    {
        /*public static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1,2,3,0,0,0 };
            int[] arr2 = new int[] { 2, 5, 6 };
            //SelectionSort(arr);
            //BubbleSort(arr);
            //InsertionSort(arr);
            //Console.WriteLine("Sorted Array: {0}", string.Join(",", arr));
            //Merge(arr1, arr1.Where(x => x!=0).Count(), arr2, arr2.Length);
            //Console.WriteLine("Sorted Array: {0}", string.Join(",", arr1));            
        }*/      

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m-1;
            int j = n-1;
            int k = m + n - 1;

            while(i >= 0 && j >= 0)
            {
                if(nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }

            if(i >= 0)
            {
                for(int index=i; index >=0; index--)
                {
                    nums1[k] = nums1[index];
                    k--;
                }
            }

            if (j >= 0)
            {
                for (int index = j; index >= 0; index--)
                {
                    nums1[k] = nums2[index];
                    k--;
                }
            }
        }

    }
}
