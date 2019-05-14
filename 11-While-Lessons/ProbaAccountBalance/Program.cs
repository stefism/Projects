using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDeposit = int.Parse(Console.ReadLine());
            int compareDeposits = 1;

            double depositAmount = double.Parse(Console.ReadLine());

            double total = 0;

            while (numberOfDeposit >= compareDeposits)
            {
                
                if (depositAmount < 1)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                depositAmount = double.Parse(Console.ReadLine());
                Console.WriteLine($"Increase: {depositAmount:F2}");
                depositAmount = depositAmount + total;
                total = depositAmount;
                compareDeposits = compareDeposits++;

                if (numberOfDeposit == compareDeposits - 1)
                {
                    break;
                }


            }

            Console.WriteLine($"Total: {total:F2}");


        }
    }
}
