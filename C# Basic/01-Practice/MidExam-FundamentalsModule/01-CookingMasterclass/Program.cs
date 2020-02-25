using System;

namespace _01_CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            // (Demo) Technology Fundamentals Mid Exam - 02 March 2019

            BudgetStudentsAndPrices budgetStudentsAndPrices = new BudgetStudentsAndPrices();

            budgetStudentsAndPrices.Budget = double.Parse(Console.ReadLine());
            budgetStudentsAndPrices.Students = int.Parse(Console.ReadLine());
            budgetStudentsAndPrices.PriceFloorForPackage = double.Parse(Console.ReadLine());
            budgetStudentsAndPrices.PriceForOneEgg = double.Parse(Console.ReadLine());
            budgetStudentsAndPrices.PriceForOneApron = double.Parse(Console.ReadLine());

            budgetStudentsAndPrices.ItemsPrice = CalculateItemsPrice(budgetStudentsAndPrices.Budget,
                budgetStudentsAndPrices.Students, budgetStudentsAndPrices.PriceFloorForPackage,
                budgetStudentsAndPrices.PriceForOneEgg, budgetStudentsAndPrices.PriceForOneApron);

            if (budgetStudentsAndPrices.ItemsPrice <= budgetStudentsAndPrices.Budget)
            {
                Console.WriteLine($"Items purchased for {budgetStudentsAndPrices.ItemsPrice:F2}$.");
            }
            else
            {
                double needMoney = budgetStudentsAndPrices.ItemsPrice - budgetStudentsAndPrices.Budget;
                Console.WriteLine($"{needMoney:F2}$ more needed.");
            }

        }

        static double CalculateItemsPrice(double budget, double students, double floor, double egg, double apron)
        {
            int percentMoreStudents = (int)Math.Ceiling(students * 0.2);
            int totalStudents = (int)students + percentMoreStudents;

            double apronsPrice = (apron * totalStudents);
            double eggsPrice = egg * 10 * students;

            int flourFreePackages = (int)students / 5;

            double flourPrice = floor * (students - flourFreePackages);

            double itemsPrice = apronsPrice + eggsPrice + flourPrice;

            return itemsPrice;
        }
    }

    class BudgetStudentsAndPrices
    {
        public double Budget;
        public double Students;
        public double PriceFloorForPackage;
        public double PriceForOneEgg;
        public double PriceForOneApron;

        public double ItemsPrice;
    }
}
