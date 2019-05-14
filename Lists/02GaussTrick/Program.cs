using System;
using System.Collections.Generic;
using System.Linq;

namespace _02GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int origilanLength = numbers.Count;

            for (int i = 0; i < origilanLength / 2; i++)
            {
                numbers[i] += numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
