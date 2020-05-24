using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Algorithms
{
    class SortingAlgos
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 2,4,1,6,8,5,3,7 };
            //SelectionSort(arr);            
            //InsertionSort(arr);
            //BubbleSort(arr);            
            //var result = MergeSort(arr);            
        }

        //https://www.youtube.com/watch?v=GUDLRan2DWM&list=PL2_aWCzGMAwKedT2KfDMB9YA5DgASZb3U&index=2
        //Best case: O(n) since while won't be executed, worst: O(n^2)
        public static void SelectionSort<T> (T[] arr) where T:IComparable
        {
            Console.WriteLine("Original Array: " + string.Join(" | ", arr)); 

            if (arr.Length <= 0 || arr.Length == 1)
                return;

            for (int i = 0; i < arr.Length-1; i++)
            {
                int minIndex = i;
                T minValue = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = arr[j];
                    }
                }
                //Swap
               Swap(arr, i, minIndex);
            }

            Console.WriteLine("Sorted Array: " + string.Join(" | ", arr)); 
        }

        //O(n^2)
        //1st element of the array is always considered in the "sorted" part
        //beginning from the 2nd element, find the next and "add" it to the 
        //correct location. Then repeat
        public static void InsertionSort<T> (T[] arr) where T:IComparable
        {
            if (arr.Length <= 0 || arr.Length == 1)
                return;

            Console.WriteLine("Original Array: " + string.Join(" | ", arr)); 

            for(int i=1; i<arr.Length; i++) 
            {
                int j = i;
                while(j > 0 && arr[j].CompareTo(arr[j-1]) < 0)
                {
                    Swap(arr, j, j-1);
                    j--;
                }
            }

            

            Console.WriteLine("Sorted Array: " + string.Join(" | ", arr)); 
        }

        //https://www.youtube.com/watch?v=Jdtq5uKz-w4&list=PL2_aWCzGMAwKedT2KfDMB9YA5DgASZb3U&index=3
        //O(n^2)
        public static void BubbleSort<T> (T[] arr) where T:IComparable
        {
            if (arr.Length <= 0 || arr.Length == 1)
                return;

            Console.WriteLine("Original Array: " + string.Join(" | ", arr)); 

            for (int i = 0; i < arr.Length; i++)
            {
                bool isAnyChange = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        isAnyChange = true;
                        Swap(arr, j, j+1);                        
                    }                    
                }                      
                if(!isAnyChange)
                    break;
            }
            Console.WriteLine("Sorted Array: " + string.Join(" | ", arr));             
        }       

        //https://www.youtube.com/watch?v=TzeBrDU-JaY&list=PL2_aWCzGMAwKedT2KfDMB9YA5DgASZb3U&index=5
        //O(n log n)
        //Stable sorting algorithm
        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            var mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
                left[i] = arr[i];

            for (int i = mid; i < arr.Length; i++)
                right[i-mid] = arr[i];

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);            
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] arr = new int[left.Length + right.Length];

            int i = 0, j = 0, k = 0;
            while(i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i]; i++;
                }
                else
                {
                    arr[k] = right[j]; j++;
                }
                k++;
            }
            while (i < left.Length)
            {
                arr[k] = left[i]; k++; i++;
            }
            while (j < right.Length)
            {
                arr[k] = right[j]; k++; j++;
            }

            return arr;
        }

        private static void Swap<T>(T[] array, int first, int second) 
        { 
            T temp = array[first]; 
            array[first] = array[second]; 
            array[second] = temp; 
        } 
    }
}
