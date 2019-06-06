using System;
using System.Numerics;

namespace _03BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int facturielNumber = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = 1; i <= facturielNumber; i++)
            {
                result = result * i;
            }

            Console.WriteLine(result);
        }
    } 
}
