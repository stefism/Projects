using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int totalSum = 0;
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int sum = int.Parse(Console.ReadLine());

                if (sum > maxNumber)
                {
                    maxNumber = sum;
                }

                totalSum += sum;
            }

            if ((totalSum - maxNumber) == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNumber - (totalSum - maxNumber))}");
            }
        }
    }
}
