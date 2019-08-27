using System;
using System.Linq;

namespace _04_AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(", ")
                .Select(double.Parse).Select(x => x * 1.2)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
