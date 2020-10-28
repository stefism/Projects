using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfInput; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber] = 0;
                }

                numbers[currentNumber]++;
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => x.Value % 2 == 0)
            .SingleOrDefault().Key));
        }
    }
}
