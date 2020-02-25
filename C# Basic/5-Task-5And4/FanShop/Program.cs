using System;

namespace FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //28 и 29 Юли 2018. Задача 5. Фен магазин

            int budget = int.Parse(Console.ReadLine());
            int itemsNumber = int.Parse(Console.ReadLine());

            double itemPrice = 0;
            double totalSumItems = 0;
            

            for (int i = 0; i < itemsNumber; i++)
            {
                string itemName = Console.ReadLine();

                switch (itemName)
                {
                    case "hoodie":

                        itemPrice = 30.00;

                        break;

                    case "keychain":

                        itemPrice = 4.00;

                        break;

                    case "T-shirt":

                        itemPrice = 20.00;

                        break;

                    case "flag":

                        itemPrice = 15.00;

                        break;

                    case "sticker":

                        itemPrice = 1.00;

                        break;
                }

                totalSumItems += itemPrice;
            }

            if (budget >= totalSumItems)
            {
                Console.WriteLine($"You bought {itemsNumber} items and left with {budget - totalSumItems} lv.");
            }

            else
            {
                Console.WriteLine($"Not enough money, you need {totalSumItems - budget} more lv.");
            }
        }
    }
}
