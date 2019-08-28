using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumberFunction = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                return minValue;
            };

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int minNumber = minNumberFunction(inputNumbers);

            Console.WriteLine(minNumber);
        }
    }
}
