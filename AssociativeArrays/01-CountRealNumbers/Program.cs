using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();

            var counts = new SortedDictionary<double, int>();

            foreach (var item in input)
            {
                if (!counts.ContainsKey(item))
                {
                    counts[item] = 1;
                }
                else
                {
                    counts[item]++;
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
