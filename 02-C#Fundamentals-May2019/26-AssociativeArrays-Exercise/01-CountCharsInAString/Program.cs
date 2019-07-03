using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            var charCount = new Dictionary<char, int>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (!charCount.ContainsKey(inputString[i]))
                {
                    charCount[inputString[i]] = 1;
                }
                else
                {
                    charCount[inputString[i]]++;
                }
            }

            foreach (var item in charCount)
            {
                if (item.Key != ' ')
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}
