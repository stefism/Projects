using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._EgyptianFractions
{
    class EgyptianFractions
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split("/");

            long numerator = long.Parse(number[0]); //Числител (43)
            long denominator = long.Parse(number[1]); //Знаменател (48)

            if (denominator < numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{numerator}/{denominator} = ");

            int index = 2;

            var result = new List<int>();

            while (numerator != 0)
            {
                // 1/2
                long nextNumerator = numerator * index; // 43 * 2
                long indexNumerator = denominator; //48

                long remaining = nextNumerator - indexNumerator; //86 - 48

                if (remaining < 0)
                {
                    index++;
                    continue;
                }

                result.Add(index);

                numerator = remaining;
                denominator *= index;

                index++;                
            }

            Console.WriteLine(string.Join(" + ", result.Select(r => $"1/{r}")));
        }
    }
}
