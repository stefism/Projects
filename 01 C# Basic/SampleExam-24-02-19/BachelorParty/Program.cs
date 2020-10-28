using System;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double singerMoney = double.Parse(Console.ReadLine());
            double moneyPerGroup = 0;
            double totalMoneyOfGroups = 0;
            int guestCounter = 0;

            while (true)
            {
                string numberOfPeoplePerGroup = Console.ReadLine();

                if (numberOfPeoplePerGroup == "The restaurant is full")
                {
                    if (totalMoneyOfGroups >= singerMoney)
                    {
                        Console.WriteLine($"You have {guestCounter} guests and {totalMoneyOfGroups - singerMoney} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {guestCounter} guests and {totalMoneyOfGroups} leva income, but no singer.");
                    }
                    break;
                }

                int groupOfPeopleNumber = int.Parse(numberOfPeoplePerGroup);
                guestCounter += groupOfPeopleNumber;

                if (groupOfPeopleNumber < 5)
                {
                    moneyPerGroup = groupOfPeopleNumber * 100;
                    totalMoneyOfGroups += moneyPerGroup;
                }
                else
                {
                    moneyPerGroup = groupOfPeopleNumber * 70;
                    totalMoneyOfGroups += moneyPerGroup;
                }
            }
        }
    }
}
