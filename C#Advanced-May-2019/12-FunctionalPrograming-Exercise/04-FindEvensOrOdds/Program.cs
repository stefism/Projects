using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArea = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int startNumber = numbersArea[0];
            int endNumber = numbersArea[1];

            List<int> numbers = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0; // Predicate<int> isOdd = n => n % 2 == 1; дава 60 от 100. Защо?

            string evenOrOdd = Console.ReadLine();

            if (evenOrOdd == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => isOdd(x))));
            }
            else if (evenOrOdd == "even")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => isEven(x))));
            }
        }
    }
}
