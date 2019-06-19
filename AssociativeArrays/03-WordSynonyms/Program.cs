using System;
using System.Collections.Generic;

namespace _03_WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>(); //  или dictionary.Add(word, new List<string>());
                }

                dictionary[word].Add(synonym);
            }
        }
    }
}
