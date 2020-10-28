using System;

namespace HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int desiredHeight = int.Parse(Console.ReadLine());
            int currentHeight = desiredHeight - 30;
            int failedJump = 0;
            int totalJump = 0;

            while (true)
            {
                int currentJump = int.Parse(Console.ReadLine());

                if (currentJump > currentHeight)
                {
                    totalJump++;
                    currentHeight += 5;
                    failedJump = 0;
                }
                else if (currentJump <= currentHeight)
                {
                    failedJump++;
                    totalJump++;
                }

                if (failedJump == 3)
                {
                    Console.WriteLine($"Tihomir failed at {desiredHeight}cm after {totalJump} jumps.");
                    break;
                }

                if (currentJump > desiredHeight)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {currentHeight}cm after {totalJump} jumps.");
                    break;
                }
            }
        }
    }
}
