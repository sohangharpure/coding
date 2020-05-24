using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.CCI.Ch1
{
    //Implement an algorithm to determine if a string has all unique characters. What if you
    //cannot use additional data structures?
    public class IsUniqueString
    {
        /*public static void Main(String[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(isUniqueStringWithoutDataStructures(input.ToLower().Trim()).ToString());
            Console.WriteLine(isUniqueStringWithoutDataStructures(input.ToLower().Trim()).ToString());
        }*/


        //O(n*n)
        public static bool isUniqueStringWithoutDataStructures(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return false;

            if (input.Length == 1)
                return true;

            for(int i=0; i<input.Length; i++)
            {
                for(int j=i+1;j<input.Length;j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }
            return true;            
        }

        //O(n)
        public static bool isUniqueStringWithDataStructures(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return false;

            if (input.Length == 1)
                return true;

            Dictionary<char, int> seenUnseen = new Dictionary<char, int>();

            for(int i=0; i<input.Length; i++)
            {
                if (!seenUnseen.ContainsKey(input[i]))
                    seenUnseen.Add(input[i], 1);
                else
                    return false;
            }

            return true;
        }

    }
}
