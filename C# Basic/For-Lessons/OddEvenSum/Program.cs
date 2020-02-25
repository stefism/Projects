using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalOddSum = 0;
            int totalEvenSum = 0;

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (i % 2 == 0)

                {
                    totalEvenSum += numbers;
                }
                else
                {
                    totalOddSum += numbers;
                }
            }

            if (totalOddSum == totalEvenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {totalOddSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(totalOddSum - totalEvenSum)}");
            }
        }
    }
}
