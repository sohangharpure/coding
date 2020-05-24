using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problems.Adhoc
{
    class GSInterview
    {
        class CountNumbersSolution
        {
            public static int CountNumbers(int[] numbers, int q)
            {
                int result = 0;
                for (int i = numbers[0]; i <= numbers[1]; i++)
                {
                    var product = i * q;
                    if (!(GetDigits(product).Intersect(GetDigits(i)).Any()))
                        result++;
                }
                return result;
            }

            private static List<int> GetDigits(int number)
            {
                List<int> digits = new List<int>();
                if (number == 0)
                {
                    digits.Add(0);
                    return digits;
                }
                while (number != 0)
                {
                    digits.Add(number % 10);
                    number /= 10;
                }
                return digits;
            }
        }

        /*
         * Given an integer array of size n. Elements of the array is >= 0. Starting from arr[startInd], follow each element to the 
         * index it points to. Find a cycle and return its length. No cycle is found -> -1.
         * 
         * lengthOfCycle([1, 0], 0); // 2
           lengthOfCycle([1, 2, 0], 0); // 3
           lengthOfCycle([1, 2, 3, 1], 0); // 3
         * 
         * */
        class LengthOfCycleSolution
        {
            public static int LengthOfCycle(int[] arr, int startIndex)
            {
                if (arr == null || arr.Length == 0 || arr.Length == 1 || startIndex < 0 || startIndex > arr.Length)
                    return -1;

                Dictionary<int, int> seenUnseen = new Dictionary<int, int>();
                seenUnseen.Add(0, -1);

                int currIndex = startIndex, index = 0;
                while(currIndex < arr.Length)
                {
                    if(seenUnseen.ContainsKey(arr[currIndex]))
                    {
                        return index - seenUnseen[arr[currIndex]];
                    }
                    seenUnseen.Add(arr[currIndex], index++);
                    currIndex = arr[currIndex];
                }

                return -1;
            }
        }

        public static string[] MaxAverage(string[][] grades)
        {
            Dictionary<string, List<double>> averageGrades = new Dictionary<string, List<double>>();
            string maxStudent = string.Empty;
            double maxAverage = -1;

            foreach (var grade in grades)
            {
                if (!averageGrades.ContainsKey(grade[0]))
                {
                    List<double> points = new List<double>();
                    points.Add(double.Parse(grade[1]));
                    averageGrades.Add(grade[0], points);
                    if (points.Average() > maxAverage)
                    {
                        maxStudent = grade[0];
                        maxAverage = points.Average();
                    }

                }
                else
                {
                    List<double> points = averageGrades[grade[0]];
                    points.Add(double.Parse(grade[1]));
                    averageGrades[grade[0]] = points;
                    if (points.Average() > maxAverage)
                    {
                        maxStudent = grade[0];
                        maxAverage = points.Average();
                    }
                }
            }

            return new string[] { maxStudent, maxAverage.ToString() };
        }

        public static int[] MoveAllZerosToBeginning(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;

            int index = arr.Length - 1;

            for (int i = index; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                    index--;
                }
            }

            return arr;
        }

        public static bool IsAnagram(string s1, string s2)
        {
            if (s1 == null || s1.Length == 0 || s2 == null || s2.Length == 0)
                return false;

            if (s1.Length != s2.Length)
                return false;

            return s1.Equals(String.Concat(s2.OrderBy(x => x)));
        }

        public static bool IsAnagramWithDict(string s1, string s2)
        {
            if (s1 == null || s1.Length == 0 || s2 == null || s2.Length == 0)
                return false;

            if (s1.Length != s2.Length)
                return false;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0, j = 0; i < s1.Length && j < s2.Length; i++, j++)
            {
                if (!charCount.ContainsKey(s1[i]))
                    charCount.Add(s1[i], 0);

                if (!charCount.ContainsKey(s2[j]))
                    charCount.Add(s2[j], 0);

                charCount[s1[i]]++;
                charCount[s2[j]]--;
            }

            bool result = true;

            foreach (var c in charCount.Keys)
            {
                if (charCount[c] != 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static int NoOfStepsRecursive(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            if (n == 2)
                return 2;

            return NoOfStepsRecursive(n - 1) + NoOfStepsRecursive(n - 2) + NoOfStepsRecursive(n - 3);
        }

        public static int NoOfStepsDP(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 1;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 3] + dp[i - 2] + dp[i - 1];
            }

            return dp[n];

        }

        public static int SecondMinimum(int[] arr)
        {
            if (arr.Length == 0)
                return int.MinValue;

            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (int num in arr)
            {
                if (num < firstMin)
                {
                    secondMin = firstMin;
                    firstMin = num;
                }
                else if (num < secondMin && num != firstMin)
                    secondMin = num;
            }

            if (secondMin == int.MaxValue)
                Console.WriteLine("No second Min found!");

            return secondMin;
        }

        public static string RunLengthEncoding(string s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s))
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            char currentChar = default(char);
            int currentCharCounter = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (currentChar == default(char))
                {
                    currentChar = s[i];
                    currentCharCounter++;
                }
                else
                {
                    //Next char = previously seen
                    if (currentChar == s[i])
                    {
                        currentCharCounter++;
                    }
                    else
                    {
                        builder.Append(currentChar);
                        builder.Append(currentCharCounter);
                        currentChar = s[i];
                        currentCharCounter = 1;
                    }
                    if (i == s.Length - 1)
                    {
                        builder.Append(currentChar);
                        builder.Append(currentCharCounter);
                    }
                }
            }

            return builder.ToString();

        }

        public static string ReverseWords(string s)
        {
            s = s.Trim();
            StringBuilder sb = new StringBuilder();
            int startIndex = 0, endIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    endIndex = i - 1;
                    sb.Append(ReverseHelper(s.Substring(startIndex, endIndex - startIndex + 1).ToCharArray(), startIndex, endIndex));
                    startIndex = i + 1;
                    continue;
                }
            }

            return s;
        }

        public static string ReverseHelper(char[] reversed, int start, int end)
        {
            if (start == end)
                return reversed.ToString();

            while (start <= end)
            {
                reversed[start] = reversed[end];
                start++;
                end--;
            }

            return reversed.ToString();
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int currIndex = 0, count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[currIndex])
                {
                    nums[++currIndex] = nums[i];
                    count = 0;
                }
                else if (count < 2)
                {
                    nums[++currIndex] = nums[i];
                }
                count++;
            }
            return currIndex + 1;
        }


        public static void Main(string[] args)
        {
            /*

            Console.WriteLine(CountNumbersSolution.CountNumbers(new int[] { 0, 5 }, 2));

            Console.WriteLine(LengthOfCycleSolution.LengthOfCycle(new int[] { 1, 2, 3, 1 }, 0));

            int[] arr = new int[] { 1, 1, 1, 2, 2, 3 };
            Console.WriteLine(RemoveDuplicates(arr));            

            Console.WriteLine(RunLengthEncoding("abcde"));

            Console.WriteLine(ReverseWords("a good   example"));

            Console.WriteLine(SecondMinimum(new int[] { 12, 13, 1, 10, 34, 1 }));

            Console.WriteLine(NoOfStepsDP(4));

            Console.WriteLine(IsAnagramWithDict("abcde", "ecabd"));

            Console.WriteLine(MoveAllZerosToBeginning(new int[] { 1, 0, 2, 0, 3 }));

            string[][] arrmarks  = new string[][]{
                new string[] { "Bob","87"},
                new string[] { "Mike", "35"},
                new string[] { "Bob", "52"},
                new string[] { "Jason","35"},
                new string[] { "Mike", "55"},
                new string[] { "Jessica", "99"}
            };

            Console.WriteLine(MaxAverage(arrmarks));

            Console.WriteLine(MoveAllZerosToBeginning(new int[] { 1, 0, 2, 0, 0, 3 }));

            */

            Console.WriteLine(LengthOfCycleSolution.LengthOfCycle(new int[] { 2, 3, 0 }, 0));

            Console.ReadKey();
        }
    }
}
