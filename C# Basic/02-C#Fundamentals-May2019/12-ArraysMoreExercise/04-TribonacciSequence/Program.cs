using System;
using System.Numerics;

namespace _04_TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] numbers = new int[input];

            numbers[0] = 1;
            numbers[1] = 1;
            numbers[2] = 2;

            for (int i = 3; i <= numbers.Length-1; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
