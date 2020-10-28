using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            double sumToGo = 0;
            double spendMoney = 0;
            double minBudget = 0;

            string destination = Console.ReadLine();

            if (destination == "End")
            {
                
            }
            else
            {
                minBudget = double.Parse(Console.ReadLine());
            }
            

            while (destination != "End")
            {
                
                if (destination == "End")
                {
                    break;
                }

                spendMoney = double.Parse(Console.ReadLine());

                sumToGo += spendMoney;

                if (sumToGo >= minBudget)
                {
                    Console.WriteLine($"Going to {destination}!");
                    sumToGo = 0;
                    destination = Console.ReadLine();

                    if (destination == "End")
                    {
                        break;
                    }

                    minBudget = double.Parse(Console.ReadLine());
                }

                
            }

        }
    }
}
