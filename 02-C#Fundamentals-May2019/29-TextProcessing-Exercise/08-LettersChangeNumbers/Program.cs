using System;
using System.Linq;

namespace _08_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine().Split();
            string string1 = inputString[0];
            string string2 = inputString[1];

            char firstLetterString1 = string1[0];
            char lastLetterString1 = string1[string1.Length - 1];
            string numberString1 = string1.Substring(1, string1.Length - 2);
        }
    }
}
