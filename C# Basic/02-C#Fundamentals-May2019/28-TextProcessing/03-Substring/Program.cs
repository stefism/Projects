using System;

namespace _03_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine().ToLower();
            string secondString = Console.ReadLine();

            while (secondString.Contains(firstString))
            {
                secondString = secondString.Replace(firstString, string.Empty);
            }

            Console.WriteLine(secondString);
        }
    }
}
