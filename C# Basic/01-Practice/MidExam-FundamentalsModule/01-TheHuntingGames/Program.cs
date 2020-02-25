using System;

namespace _01_TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Mid Exam - 10 March 2019 Group 2

            int daysOfAdventure = int.Parse(Console.ReadLine());
            int playersNumber = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayForOnePerson = double.Parse(Console.ReadLine());
            double foodPerDayForOnePerson = double.Parse(Console.ReadLine());

            double totalWater = daysOfAdventure * playersNumber * waterPerDayForOnePerson;
            double totalFood = daysOfAdventure * playersNumber * foodPerDayForOnePerson;

            for (int days = 1; days <= daysOfAdventure; days++)
            {
                double energyLost = double.Parse(Console.ReadLine());
                groupEnergy -= energyLost;

                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    return;
                }

                if (days % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    totalWater *= 0.70;
                }

                if (days % 3 == 0)
                {
                    totalFood = totalFood - (totalFood / playersNumber);
                    groupEnergy *= 1.10;
                }
            }

            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
            }
        }
    }
}
