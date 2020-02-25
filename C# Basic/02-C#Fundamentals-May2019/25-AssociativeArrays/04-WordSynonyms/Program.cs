using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());

            var synonymsDictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < total; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!synonymsDictionary.ContainsKey(word))
                {
                    synonymsDictionary[word] = new List<string>();
                }

                synonymsDictionary[word].Add(synonym);
            }

            foreach (var item in synonymsDictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
