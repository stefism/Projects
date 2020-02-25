using System;

namespace FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMatchResult = Console.ReadLine();
            string secondMatchResult = Console.ReadLine();
            string thirdMatchResult = Console.ReadLine();

            int teamWin = 0;
            int teamLost = 0;
            int teamRemi = 0;

            int firstMatch1 = int.Parse(firstMatchResult[0].ToString());
            int firstMatch3 = int.Parse(firstMatchResult[2].ToString());

            int secondMatch1 = int.Parse(secondMatchResult[0].ToString());
            int secondMatch3 = int.Parse(secondMatchResult[2].ToString());

            int thirdMatch1 = int.Parse(thirdMatchResult[0].ToString());
            int thirdMatch3 = int.Parse(thirdMatchResult[2].ToString());

            if (firstMatch1 > firstMatch3)
            {
                teamWin++;
            }
            else if (firstMatch1 < firstMatch3)
            {
                teamLost++;
            }
            else if (firstMatch1 == firstMatch3)
            {
                teamRemi++;
            }

            if (secondMatch1 > secondMatch3)
            {
                teamWin++;
            }
            else if (secondMatch1 < secondMatch3)
            {
                teamLost++;
            }
            else if (secondMatch1 == secondMatch3)
            {
                teamRemi++;
            }

            if (thirdMatch1 > thirdMatch3)
            {
                teamWin++;
            }
            else if (thirdMatch1 < thirdMatch3)
            {
                teamLost++;
            }
            else if (thirdMatch1 == thirdMatch3)
            {
                teamRemi++;
            }

            Console.WriteLine($"Team won {teamWin} games.");
            Console.WriteLine($"Team lost {teamLost} games.");
            Console.WriteLine($"Drawn games: {teamRemi}");
        }
    }
}
