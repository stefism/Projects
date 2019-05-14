
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count-1; i++)
            {
                bool isBigger = true;

                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            Console.WriteLine(numbers[numbers.Count-1]);
        }
    }
}
