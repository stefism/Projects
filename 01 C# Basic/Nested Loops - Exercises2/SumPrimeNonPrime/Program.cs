using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            if (numbers % numbers == 0 && numbers % 1 == 0)
            {
                Console.WriteLine("Number is Prime.");
            }
            else
            {
                Console.WriteLine("NOT Prime.");
            }
        }
    }
}
