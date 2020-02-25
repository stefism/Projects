using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _06_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cars> cars = new List<Cars>();

            while (true)
            {
                List<string> currentCarInfo = Console.ReadLine().Split().ToList();

                if (currentCarInfo[0] == "End")
                {
                    break;
                }

                Cars currentCar = new Cars(currentCarInfo[0], currentCarInfo[1], currentCarInfo[2], int.Parse(currentCarInfo[3]));

                cars.Add(currentCar);
            }

            while (true)
            {
                string carModel = Console.ReadLine();

                if (carModel == "Close the Catalogue")
                {
                    break;
                }

                foreach (var item in cars)
                {
                    if (item.Model == carModel)
                    {
                        string type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Type);
                        Console.WriteLine($"Type: {type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
            }

            double carsHorsePower = 0;
            double trucksHorsePower = 0;

            int carCounter = 0;
            int truckCounter = 0;

            foreach (var item in cars)
            {
                if (item.Type == "car")
                {
                    carsHorsePower += item.HorsePower;
                    carCounter++;
                }
                else
                {
                    trucksHorsePower += item.HorsePower;
                    truckCounter++;
                }
            }

            // Така не работи!
            // И пак - ако и двете са нули, влиза в първия иф - печата и horsepower 
            //на trucks е NaN. Печатане да става само на едно място, a в ифовете 
            //слагаш стойности 0 на даден horsepower

            //double averageCarsHorsePower = carsHorsePower / carCounter;
            //double averageTrucksHorsePower = trucksHorsePower / truckCounter;

            //if (carCounter == 0)
            //{
            //    Console.WriteLine($"Cars have average horsepower of: 0.00");
            //    Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
            //}
            //else if (truckCounter == 0)
            //{
            //    Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            //    Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            //}

            //else if (carCounter == 0 && truckCounter == 0)
            //{
            //    Console.WriteLine($"Cars have average horsepower of: 0.00");
            //    Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            //}

            //else if (truckCounter > 0 && carCounter > 0)
            //{
            //    Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            //    Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
            //}

            /*
             * а може би Джъдж очаква вместо 0.00 -> 0,00 :) няма смисъл да ги кодваш по този начин, 
             * защото не знаеш винаги на какви машини с локални настройки ще се изпълнява. 
             * Просто проверяваш ако count-ера е 0 и другото е 0 и това е.
             */

            // Така работи!

            double averageCarsHorsePower = carsHorsePower / carCounter;
            double averageTrucksHorsePower = trucksHorsePower / truckCounter;

            if (carCounter == 0)
            {
                averageCarsHorsePower = 0;
            }
                
            if (truckCounter == 0)
            {
                averageTrucksHorsePower = 0;
            }
                
            Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
        }
    }
    class Cars
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Cars(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }
}
