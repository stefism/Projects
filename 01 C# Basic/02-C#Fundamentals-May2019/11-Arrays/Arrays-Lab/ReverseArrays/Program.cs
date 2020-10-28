using System;
using System.Linq;

namespace ReverseArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Когато не искаме да създаваме нов масив

            string[] texts = Console.ReadLine().Split();

            for (int i = 0; i < texts.Length / 2; i++)
            {
                string first = texts[i];
                string last = texts[texts.Length - i - 1];

                texts[i] = last;
                texts[texts.Length - i - 1] = first;
            }

            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine(texts[i]);
            }
        }
    }
}
