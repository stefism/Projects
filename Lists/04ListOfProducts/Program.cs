using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFruits = int.Parse(Console.ReadLine());

            List<string> fruits = new List<string>();

            for (int i = 0; i < numberOfFruits; i++)
            {
                fruits.Add(Console.ReadLine());
            }

            fruits.Sort();

            for (int i = 1; i <= numberOfFruits; i++)
            {
                Console.WriteLine($"{i}.{fruits[i-1]}");
            }
        }
    }
}
