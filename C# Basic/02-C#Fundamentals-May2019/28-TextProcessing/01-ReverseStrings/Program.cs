using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string inputString = Console.ReadLine();
                string reversedString = Reverse(inputString);

                if (inputString == "end")
                {
                    break;
                }

                Console.WriteLine($"{inputString} = {reversedString}");
            }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
