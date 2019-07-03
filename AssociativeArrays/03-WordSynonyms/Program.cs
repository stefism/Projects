using System;
using System.Collections.Generic;

namespace _03_WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int words = int.Parse(Console.ReadLine());
            var synonymsWords = new Dictionary<string, List<string>>();

            for (int i = 0; i < words; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                //if (synonymsWords.ContainsKey(word))
                //{
                //    synonymsWords[word].Add(synonym);
                //}

                //else
                //{
                //    synonymsWords[word] = new List<string>();
                //    synonymsWords[word].Add(synonym); // Повтарящ се код!
                //}

                if (!synonymsWords.ContainsKey(word))
                {
                    synonymsWords[word] = new List<string>();
                }

                synonymsWords[word].Add(synonym);
                // Когато имаме повтарящ се код, го изнасяме извън проверки и неща.
                // Не е хубаво да имаме код, който се повтаря.
            }

            foreach (var item in synonymsWords)
            {
                Console.WriteLine(item.Key + " - " + string.Join(", ", item.Value));
            }
        }
    }
}
