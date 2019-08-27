using System;
using System.Linq;

namespace _02_SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Console.WriteLine(inputNumbers.Length);
            Console.WriteLine(inputNumbers.Sum());
        }
    }
}
