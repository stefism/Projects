using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputWords = Console.ReadLine().Split().ToList();
            var oddWords = new Dictionary<string, int>();

            foreach (var item in inputWords)
            {
                string toLower = item.ToLower();

                if (!oddWords.ContainsKey(toLower))
                {
                    oddWords[toLower] = 1;
                }
                else
                {
                    oddWords[toLower]++;
                }
                
            }

            foreach (var item in oddWords)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
