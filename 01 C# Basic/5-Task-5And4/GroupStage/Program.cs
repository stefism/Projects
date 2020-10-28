using System;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            // 28 и 29 юли 2018. Задача 4. Групова фаза.

            string teamName = Console.ReadLine();
            int numberOfGames = int.Parse(Console.ReadLine());
            int points = 0;
            int totalPoints = 0;
            int goalsDiff = 0;
            int totalGoalsDiff = 0;

            int scoredGoals = 0;
            int receivedGoals = 0;

            for (int i = 0; i < numberOfGames; i++)
            {
                scoredGoals = int.Parse(Console.ReadLine());
                receivedGoals = int.Parse(Console.ReadLine());

                //goalsDiff = scoredGoals - receivedGoals;

                if (scoredGoals > receivedGoals)
                {
                    points = 3;
                    goalsDiff = scoredGoals - receivedGoals;
                }
                else if (scoredGoals == receivedGoals)
                {
                    points = 1;
                    goalsDiff = 0;
                }
                else if (scoredGoals <= receivedGoals)
                {
                    goalsDiff = scoredGoals - receivedGoals;
                }

                totalPoints += points;
                totalGoalsDiff += goalsDiff;
            }

            //goalsDiff = scoredGoals - receivedGoals;

            if (scoredGoals >= receivedGoals)
            {
                Console.WriteLine($"{teamName} has finished the group phase with {Math.Abs(totalPoints)} points.");
                Console.WriteLine($"Goal difference: {totalGoalsDiff}.");
            }
            else
            {
                Console.WriteLine($"{teamName} has been eliminated from the group phase.");

                //if (totalGoalsDiff == -0)
                //{
                //    totalGoalsDiff = 0;
                //}

                Console.WriteLine($"Goal difference: {totalGoalsDiff}.");
            }
        }
    }
}
