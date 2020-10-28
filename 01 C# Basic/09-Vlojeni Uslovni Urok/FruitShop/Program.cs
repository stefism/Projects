using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());

            bool fruitTrue = fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit"
                 || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes";

            bool dayTrue = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday"
                || day == "Friday" || day == "Saturday" || day == "Sunday";

            double banana = 0;
            double apple = 0;
            double orange = 0;
            double grapefruit = 0;
            double kiwi = 0;
            double pineapple = 0;
            double grapes = 0;

            double price = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    banana = 2.50;
                    apple = 1.20;
                    orange = 0.85;
                    grapefruit = 1.45;
                    kiwi = 2.70;
                    pineapple = 5.50;
                    grapes = 3.85;
                    break;

                case "Saturday":
                case "Sunday":
                    banana = 2.70;
                    apple = 1.25;
                    orange = 0.90;
                    grapefruit = 1.60;
                    kiwi = 3.00;
                    pineapple = 5.60;
                    grapes = 4.20;
                    break;
            }

            if (fruit == "banana")
            {
                price = banana * number;
            }
            else if (fruit == "apple")
            {
                price = apple * number;
            }
            else if (fruit == "orange")
            {
                price = orange * number;
            }
            else if (fruit == "grapefruit")
            {
                price = grapefruit * number;
            }
            else if (fruit == "kiwi")
            {
                price = kiwi * number;
            }
            else if (fruit == "pineapple")
            {
                price = pineapple * number;
            }
            else if (fruit == "grapes")
            {
                price = grapes * number;
            }

            if (!fruitTrue)
            {
                Console.WriteLine("error");
            }
            else if (!dayTrue)
            {
                Console.WriteLine("error");
            }
            else
            Console.WriteLine("{0:F2}", price);
        }

        
    }
}
