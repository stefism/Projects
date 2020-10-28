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
            var numbers = new SortedDictionary<double, int>();

            foreach (var item in input)
            {
                if (numbers.ContainsKey(item))
                {
                    numbers[item]++;
                }
                else
                {
                    numbers[item] = 1;
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
