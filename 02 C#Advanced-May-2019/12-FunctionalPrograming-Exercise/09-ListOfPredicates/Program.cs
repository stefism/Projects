using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> output = new List<int>();



            for (int i = 1; i <= endNumber; i++)
            {
                bool isDivide = true;

                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j] != 0)
                    {
                        isDivide = false;
                        break;
                    }
                }

                if (isDivide)
                {
                    output.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
