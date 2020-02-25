using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_RandomizeWordds
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<string> inputWords = Console.ReadLine().Split().ToList();

            for (int i = 0; i < inputWords.Count; i++)
            {
                int randomIndex = random.Next(0, inputWords.Count);
                string randomElement = inputWords[randomIndex];
                string currentElement = inputWords[i];

                inputWords[randomIndex] = currentElement;
                inputWords[i] = randomElement;
            }

            foreach (var item in inputWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
