using System;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTurnirs = int.Parse(Console.ReadLine());
            int startPointsInRankList = int.Parse(Console.ReadLine());

            int totalPoints = startPointsInRankList;
            double tournirPoints = 0;
            double winCounter = 0;

            for (int i = 0; i < numberOfTurnirs; i++)
            {
                string stage = Console.ReadLine();

                switch (stage)
                {
                    case "W":
                        totalPoints += 2000;
                        tournirPoints += 2000;
                        winCounter++;
                        break;

                    case "F":
                        totalPoints += 1200;
                        tournirPoints += 1200;
                        break;

                    case "SF":
                        totalPoints += 720;
                        tournirPoints += 720;
                        break;
                }
            }

            Console.WriteLine($"Final points: {totalPoints}");

            double averagePoints = tournirPoints / numberOfTurnirs;

            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");

            double percentWin = (winCounter / numberOfTurnirs) * 100;

            Console.WriteLine($"{percentWin:F2}%");
        }
    }
}
