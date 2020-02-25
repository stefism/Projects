using System;
using System.Linq;

namespace ReverseArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Когато искаме да създадем нов масив

            string[] texts = Console.ReadLine().Split();
            string[] results = new string[texts.Length];

            for (int i = 0; i < texts.Length; i++)
            {
                results[i] = texts[texts.Length - i - 1];
            }

            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
