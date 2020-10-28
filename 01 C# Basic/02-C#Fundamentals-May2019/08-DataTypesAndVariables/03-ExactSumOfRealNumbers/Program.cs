using System;
using System.Numerics;

namespace _03_ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
