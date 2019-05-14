using System;
using System.Collections.Generic;
using System.Linq;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ');
            var random = new Random();
            var shuffleWords = new List<string>();

            foreach (var item in words)
            {
                int newIndex = random.Next(0, shuffleWords.Count + 1);
                shuffleWords.Insert(newIndex, item);
            }

            foreach (var item in shuffleWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
