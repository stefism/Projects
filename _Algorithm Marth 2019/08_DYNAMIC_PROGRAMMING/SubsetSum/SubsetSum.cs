using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum //Without repeat numbers
{
    class SubsetSum
    {
        static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();

            result.Add(0, 0); // sum -> how it obtained

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
               
                foreach (var number in result.Keys.ToList())
                {
                    int newSum = number + currentNumber;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }

            return result;
        }

        static void Main()
        {
            var numbers = new int[] { 3, 5, 1, 4, 2 };

            var sums = CalcSums(numbers);

            Console.Write("Target sum: ");
            var targetSum = int.Parse(Console.ReadLine());

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("Yes");

                while (targetSum != 0)
                {
                    var number = sums[targetSum];
                    Console.Write(number + " ");

                    targetSum -= number;
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
