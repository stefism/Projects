using System;

namespace EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWords = Console.ReadLine();
            string secondWords = Console.ReadLine();

            firstWords = firstWords.ToLower();
            secondWords = secondWords.ToLower();

            if (firstWords == secondWords)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
