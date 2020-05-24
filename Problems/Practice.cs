using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class Practice
    {
        private static Dictionary<int, int> computed = new Dictionary<int, int>();      

        /*public static void Main(string[] args)
        {
            //Console.WriteLine(fib_memoized_recursive(8));
            //Console.WriteLine(TwoNumberSum(new int[] { 3,5,-4,8,11,1,-1,6}, 10));

            int[,] results = new int[10,10];
            for(int i=0; i < results.Length; i++ ){
                for(int j=0; j < results.GetLength(1); j++){
                    results[i,j] = (i+1) * (j+1);
                }
            }

            Console.ReadLine();
        }*/

        public static int fib_memoized_recursive(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1 || n == 2)
            {
                if(!computed.ContainsKey(n))
                    computed[n] = 1;
                return 1;
            }
            if (computed.ContainsKey(n))
            {
                Console.WriteLine(string.Format("Returning fib {0} from cache", n));
                return computed[n];
            }
            else
            {
                computed[n] = fib_memoized_recursive(n - 1) + fib_memoized_recursive(n - 2);
                Console.WriteLine(string.Format("Computed fib {0} and stored in cache", n));
                return computed[n];
            }
        }

        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            Array.Sort(array);
            for (int i = 0,  j = array.Length - 1 ; i < array.Length && j >= 0 ;)
            {
                if (array[i] + array[j] == targetSum)
                    return new int[] { array[i], array[j] };
                else if (array[i] + array[j] < targetSum)
                    i++;
                else
                    j--;
            }
            return new int[] { };
        }
    }
}
