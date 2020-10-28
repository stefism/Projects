using System;

namespace _09_SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int numbers = 1;
            int sum = 0;

            for (int i = 0; i < input; i++)
            {
                Console.WriteLine(numbers);
                sum += numbers;
                numbers += 2;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
