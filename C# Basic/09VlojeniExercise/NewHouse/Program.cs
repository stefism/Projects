using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlowers = Console.ReadLine();
            double numberOfFlowers = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0;

            switch (typeOfFlowers)
            {
                case "Roses":
                    price = numberOfFlowers * 5;

                    if (numberOfFlowers > 80)
                    {
                        price = price - (price * 0.10);
                    }
                    break;

                case "Dahlias":
                    price = numberOfFlowers * 3.80;

                    if (numberOfFlowers > 90)
                    {
                        price = price - (price * 0.15);
                    }
                    break;

                case "Tulips":
                    price = numberOfFlowers * 2.80;

                    if (numberOfFlowers > 80)
                    {
                        price = price - (price * 0.15);
                    }
                    break;
                    
                case "Narcissus":
                    price = numberOfFlowers * 3;

                    if (numberOfFlowers < 120)
                    {
                        price = price + (price * 0.15);
                    }
                    break;

                case "Gladiolus":
                    price = numberOfFlowers * 2.50;

                    if (numberOfFlowers < 80)
                    {
                        price = price + (price * 0.20);
                    }
                    break;
            }

            double leftMoney = budget - price;
                
            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {Math.Abs(leftMoney):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(leftMoney):F2} leva more.");
            }

        }
    }
}
