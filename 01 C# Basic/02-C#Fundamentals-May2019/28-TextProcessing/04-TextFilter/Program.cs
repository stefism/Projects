using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string inputString = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                inputString = inputString.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(inputString);
        }
    }
}
