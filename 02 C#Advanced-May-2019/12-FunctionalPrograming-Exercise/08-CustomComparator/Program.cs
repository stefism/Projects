using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> output = new List<int>();

            output = inputNumbers.Where(x => x % 2 == 0).ToList();

            output.Sort();

            output.AddRange(inputNumbers.OrderBy(x => x)
                .Where(x => x % 2 != 0));

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
