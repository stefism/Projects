using System;
using System.Linq;
using System.Numerics;

namespace _02_FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfLines; i++)
            {
                long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
                long sum = 0;

                if (numbers[0] >= numbers[1])
                {
                    long leftNumber = Math.Abs(numbers[0]);

                    while (leftNumber > 0)
                    {
                        long currentDigit = leftNumber % 10;
                        sum += currentDigit;
                        leftNumber /= 10;
                    }
                }

                else
                {
                    long rightNumber = Math.Abs(numbers[1]);

                    while (rightNumber > 0)
                    {
                        long currentDigit = rightNumber % 10;
                        sum += currentDigit;
                        rightNumber /= 10;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
