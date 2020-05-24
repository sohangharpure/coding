using System;

namespace Problems.AlgoExpert.Easy
{
    public class Problem
    {
        public static int[] FindThreeLargestNumbersSimple(int[] array)
        {
            // Write your code here.
            if (array == null || array.Length < 3)
                return array;

            Array.Sort(array);

            return new int[] { array[array.Length - 3], array [array.Length - 2] , array [array.Length - 1] } ;
        }

        
        //O(n) | O(1)
        public static int[] FindThreeLargestNumbers(int[] array)
        {
            // Write your code here.
            if (array == null || array.Length < 3)
                return array;

            int[] threeLargest = new int[] { int.MinValue, int.MinValue, int.MinValue };

            foreach(int num in array)
            {
                UpdateLargest(threeLargest, num);
            }

            return threeLargest;
        }

        public static void UpdateLargest(int[] threeLargest, int num)
        {
            if (num > threeLargest[2])
                ShiftAndUpdate(threeLargest, num, 2);
            else if (num > threeLargest[1])
                ShiftAndUpdate(threeLargest, num, 1);
            else if (num > threeLargest[0])
                ShiftAndUpdate(threeLargest, num, 0);
        }

        public static void ShiftAndUpdate(int[] threeLargest, int num, int index)
        {
            for(int i = 0; i <= index; i++)
            {
                if (i == index)
                    threeLargest[i] = num;
                else
                    threeLargest[i] = threeLargest[i + 1];
            }
        }

        /*public static void Main(string[] args)
        {
            int[] arr = new int[] {55,7,8};
            Console.WriteLine(String.Join(",", FindThreeLargestNumbers(arr)));
        }*/
    }
}
