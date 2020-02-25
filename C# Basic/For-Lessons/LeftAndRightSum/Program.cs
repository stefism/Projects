using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;
            int totalLeftSum = 0;
            int totalRightSum = 0;

            for (int compare = 0; compare < numbers; compare++)
            {
                sumLeft = int.Parse(Console.ReadLine());
                totalLeftSum += sumLeft;
            }

            for (int compare = 0; compare < numbers; compare++)
            {
                sumRight = int.Parse(Console.ReadLine());
                totalRightSum += sumRight;
            }

            if (totalLeftSum == totalRightSum)
            {
                Console.WriteLine($"Yes, sum = {totalLeftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(totalRightSum - totalLeftSum)}");
            }

        }
    }
}
