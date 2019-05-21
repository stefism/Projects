using System;
using System.Collections.Generic;
using System.Linq;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumberOfSieve = int.Parse(Console.ReadLine());
            List<int> sieve = new List<int>();

            for (int i = 2; i <= lastNumberOfSieve; i++)
            {
                sieve.Add(i);
            }

            for (int i = 0; i < sieve.Count; i++)
            {
                for (int j = i+1; j < sieve.Count; j++)
                {
                    if (sieve[j] % sieve[i] == 0)
                    {
                        sieve.Remove(sieve[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", sieve));
        }
    }
}
