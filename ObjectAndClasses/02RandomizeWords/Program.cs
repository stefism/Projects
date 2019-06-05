using System;
using System.Collections.Generic;
using System.Linq;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random random = new Random();
            List<string> shuffleWords = new List<string>();

            foreach (string item in words)
            {
                int newIndex = random.Next(0, shuffleWords.Count + 1);
                shuffleWords.Insert(newIndex, item);
            }

            foreach (string item in shuffleWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
