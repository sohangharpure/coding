using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    public class CaesarCypherEncryptor
    {
        public static string Encode(string str, int key)
        {
            // Write your code here.
            //handle the edge case where key > 26
            int newKey = key % 26;
            StringBuilder sb = new StringBuilder();        
            foreach (char c in str)
            {
                int value = c + newKey;
                if (value <= 122)
                    sb.Append((char)value);
                else
                    sb.Append((char)(96 + value % 122));
                
            }
            return sb.ToString();
        }

        /*public static void Main(string[] args)
        {
            Console.WriteLine(Encode("xyz", 1026));
        }*/


    }
}
