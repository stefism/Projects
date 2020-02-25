using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDeposit = int.Parse(Console.ReadLine());
            int compareDeposits = 0;

            double total = 0;

            while (numberOfDeposit > compareDeposits) 
            {
                double depositAmount = double.Parse(Console.ReadLine());

                if (depositAmount < 1)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {depositAmount:F2}");
                depositAmount = depositAmount + total;
                total= depositAmount;
                compareDeposits++;

                //if (numberOfDeposit == compareDeposits - 1)
                //{
                //    break; 
                //}

                
            }

            Console.WriteLine($"Total: {total:F2}");


        }
    }
}
