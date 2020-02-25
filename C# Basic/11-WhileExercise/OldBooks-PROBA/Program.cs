using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double needMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            double totalMoney = 0;
            //double savedMoney = availableMoney; //
            //double spendMoney = 0;

            double dayCounter = 0;
            double spendCounter = 5;

            while (true)
            {
                string action = Console.ReadLine();
                double moneySaveOrSell = double.Parse(Console.ReadLine());

                dayCounter++;

                if (action == "spend")
                {
                    spendCounter--;

                    availableMoney = availableMoney - moneySaveOrSell;
                    totalMoney = availableMoney;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                }
                else if (action == "save")
                {
                    spendCounter = 5;

                    availableMoney = availableMoney + moneySaveOrSell;
                    totalMoney = availableMoney;
                }

                if (totalMoney == needMoney)
                {
                    Console.WriteLine($"You saved the money for {dayCounter} days.");
                    break;
                }

                if (spendCounter == 0)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(dayCounter);
                    break;
                }
            } // while end
        }
    }
}
