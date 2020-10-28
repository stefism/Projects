using System;

namespace _01_TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());

            double water = days * countOfPlayers * waterPerDayPerPerson;
            double food = days * countOfPlayers * foodPerDayPerPerson;

            bool isBreaked = false;

            for (int i = 1; i <= days; i++)
            {
                double lostEnergy = double.Parse(Console.ReadLine());

                groupEnergy -= lostEnergy;

                if (groupEnergy<= 0)
                {
                    isBreaked = true;
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    water *= 0.70;
                }

                if (i % 3 == 0)
                {
                    food -= food / countOfPlayers;
                    groupEnergy *= 1.10;
                }
            }

            if (isBreaked)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {food:F2} food and {water:F2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
        }
    }
}
