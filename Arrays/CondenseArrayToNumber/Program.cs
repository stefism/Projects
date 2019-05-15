using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] condensed = new int [numbers.Length-1];

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int loopOne = 0; loopOne < numbers.Length; loopOne++)
            {
                
                for (int loopTwo = 0; loopTwo < condensed.Length - loopOne; loopTwo++)
                {
                    condensed[loopTwo] = numbers[loopTwo] + numbers[loopTwo + 1];
                }

                numbers = condensed;
            }

            Console.WriteLine(condensed[0]);

        }
    }
}
