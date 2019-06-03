using System;

namespace _01_SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Mid Exam - 10 March 2019 Group 1

            int daysOfTheTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double priceForFuelPerKilometer = double.Parse(Console.ReadLine());
            double foodExpencesForDayPerPerson = double.Parse(Console.ReadLine());
            double roomPriceForNightPerPerson = double.Parse(Console.ReadLine());

            double currentExpences = 0;

            double totalFoodExpences = foodExpencesForDayPerPerson * groupOfPeople * daysOfTheTrip;

            budget = CalculateBudget(totalFoodExpences, budget);
            currentExpences += totalFoodExpences;
            
            double totalHotelExpences = roomPriceForNightPerPerson * groupOfPeople * daysOfTheTrip;

            if (groupOfPeople >= 10)
            {
                totalHotelExpences *= 0.75;
            }

            budget = CalculateBudget(totalHotelExpences, budget);
            currentExpences += totalHotelExpences;
            
            for (int days = 1; days <= daysOfTheTrip; days++)
            {
                double totalFuelExpences = 0;
                double traveledDistance = int.Parse(Console.ReadLine());

                totalFuelExpences += traveledDistance * priceForFuelPerKilometer;
                budget = CalculateBudget(totalFuelExpences, budget);
                currentExpences += totalFuelExpences;

                if (days % 3 == 0 || days % 5 == 0)
                {
                    double extraExpences = currentExpences * 0.4;
                    budget = CalculateBudget(extraExpences, budget);
                    currentExpences += extraExpences;
                }
                else if (days % 7 == 0)
                {
                    double dayExpences = (foodExpencesForDayPerPerson * groupOfPeople)
                        + (roomPriceForNightPerPerson * groupOfPeople)
                        + totalFuelExpences;

                    double receiveMoney = currentExpences / groupOfPeople;
                    budget += receiveMoney; 
                }
            }

            Console.WriteLine($"You have reached the destination. You have {budget:F2}$ budget left.");

        }
        static double CalculateBudget(double expences, double budget)
        {
            if (expences > budget)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {(expences - budget):F2}$ more.");
                System.Environment.Exit(1);
                return budget;
            }
            else
            {
                budget -= expences;
                return budget;
            }
        }
    }
}
