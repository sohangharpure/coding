using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Leetcode
{
    class MedianOfTwoSortedArrays
    {
        /*
        public static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArraysLinq(new int[] { -5, 3, 6, 12, 15 }, new int[] { -12, -10, -6, -3, 4, 10 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { -5, 3, 6, 12, 15 }, new int[] { -12, -10, -6, -3, 4, 10 }));
            Console.Read();
        }
        */

        //Not O(log(m+n))
        public static double FindMedianSortedArraysLinq(int[] nums1, int[] nums2)
        {
            var mergedArray = nums1.Concat(nums2).OrderBy(x => x).ToArray();
            var length = mergedArray.Length;
            var element = 0;
            if (length % 2 == 0)
            {
                var middle1 = mergedArray[(length / 2) - 1];
                var middle2 = mergedArray[(length / 2)];
                return middle1 == middle2 ? middle1 : (middle1 + middle2) / 2.0;
            }
            else
            {
                element = (int)(Math.Ceiling((length / 2.0)));
                return (mergedArray[element - 1]);
            }
        }

        //O(m+n) with n+m extra space
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0, k = 0;
            int[] merged = new int[nums1.Length + nums2.Length];

            while(i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                    merged[k++] = nums1[i++];
                else
                    merged[k++] = nums2[j++];
            }

            while (i < nums1.Length)
                merged[k++] = nums1[i++];

            while (j < nums2.Length)
                merged[k++] = nums2[j++];

            int length = merged.Length;

            if (length % 2 == 0)
            {
                var middle1 = merged[(length / 2) - 1];
                var middle2 = merged[(length / 2)];
                return middle1 == middle2 ? middle1 : (middle1 + middle2) / 2.0;
            }
            else
            {
                var element = (int)(Math.Ceiling((length / 2.0)));
                return (merged[element - 1]);
            }
        }
    }
}
