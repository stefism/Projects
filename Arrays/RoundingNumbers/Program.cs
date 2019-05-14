using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            double[] numbersAsString = numbers.Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbersAsString.Length; i++)
            {
                Console.WriteLine($"{numbersAsString[i]} => {Math.Round(numbersAsString[i], MidpointRounding.AwayFromZero)}");
            }

            // int[] valuesAsString = values.Split().Select(int.Parse).ToArray();
        }
    }
}
