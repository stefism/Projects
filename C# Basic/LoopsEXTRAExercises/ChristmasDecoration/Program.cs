using System;

namespace ChristmasDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            // 22 и 23 Декември 2018 Задача 6. Коледна украса

            double budgetForDecoration = double.Parse(Console.ReadLine());
            double itemSum = 0;
            double totalItemSum = 0;

            while (true)
            {
                string item = Console.ReadLine();

                if (item == "Stop")
                {
                    Console.WriteLine($"Money left: {budgetForDecoration - totalItemSum}");
                    break;
                }

                for (int i = 0; i < item.Length; i++)
                {
                    int itemCharValue = item[i];
                    itemSum += itemCharValue;
                }

                totalItemSum += itemSum;
                //Console.WriteLine($"Item sum: {itemSum}");
                //Console.WriteLine($"Total item sum: {totalItemSum}");

                if (totalItemSum <= budgetForDecoration)
                {
                    Console.WriteLine("Item successfully purchased!");
                    itemSum = 0;
                }
                else
                {
                    Console.WriteLine("Not enough money!");
                    break;
                }

                
            }
        }
    }
}
