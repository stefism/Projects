using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                }

                return numbers;
            };

            Func<int[], int[]> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }

                return numbers;
            };

            Func<int[], int[]> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] -= 1;
                }

                return numbers;
            };

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                else if (command == "add")
                {
                    inputNumbers = add(inputNumbers);
                }

                else if (command == "multiply")
                {
                    inputNumbers = multiply(inputNumbers);
                }

                else if (command == "subtract")
                {
                    inputNumbers = subtract(inputNumbers);
                }

                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", inputNumbers));
                }
            }
        }
    }
}
