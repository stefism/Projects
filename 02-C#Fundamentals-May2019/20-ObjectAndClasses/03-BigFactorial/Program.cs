using System;
using System.Numerics;

namespace _03_BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 2; i <= inputNumber; i++)
            {
                factorial = factorial * i;
            }

            Console.WriteLine(factorial);
        }
    }
}
