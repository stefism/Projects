using System;

namespace ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeFirstBrother = double.Parse(Console.ReadLine());
            double timeSecondBrother = double.Parse(Console.ReadLine());
            double timeThirdBrother = double.Parse(Console.ReadLine());
            double timeFishing = double.Parse(Console.ReadLine());

            double cleaningTime = 1 / (1 / timeFirstBrother + 1 / timeSecondBrother
                + 1 / timeThirdBrother) * 1.15;
            double timeLeft = timeFishing - cleaningTime;

            if (cleaningTime < timeFishing)
            {
                Console.WriteLine($"Cleaning time: {cleaningTime:F2}");
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }
            else
            {
                timeLeft = Math.Abs(timeLeft);
                Console.WriteLine($"Cleaning time: {cleaningTime:F2}");
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeLeft)} hours.");
            }

        }
    }
}
