using System;
using System.Collections.Generic;
using System.Linq;

namespace _03m_SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Cars> cars = new List<Cars>();

            for (int i = 0; i < numberOfCars; i++)
            {
                List<string> currentCarInfo = Console.ReadLine().Split().ToList();
                Cars currentCar = new Cars(currentCarInfo[0], double.Parse(currentCarInfo[1]), double.Parse(currentCarInfo[2]));

                cars.Add(currentCar);
            }

            while (true)
            {
                List<string> driveInfo = Console.ReadLine().Split().ToList();

                if (driveInfo[0] == "End")
                {
                    foreach (var item in cars)
                    {
                        Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TraveledDistance}");
                    }
                    break;
                }

                string model = driveInfo[1];
                double drivedKm = double.Parse(driveInfo[2]);
                Cars.CalculateKilometers(model, drivedKm, cars);
            }
        }
    }
    class Cars
    {
        public static void CalculateKilometers(string model, double distance, List<Cars> cars)
        {
            foreach (var item in cars)
            {
                if (item.Model == model)
                {
                    if (item.FuelConsumPerKm * distance <= item.FuelAmount)
                    {
                        item.TraveledDistance += distance;
                        item.FuelAmount -= item.FuelConsumPerKm * distance;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                        break;
                    }
                }
            }
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumPerKm { get; set; }
        public double TraveledDistance { get; set; }

        public Cars(string model, double fuelAMount, double fuelConsumPerKm, double traveledDistance = 0)
        {
            this.Model = model;
            this.FuelAmount = fuelAMount;
            this.FuelConsumPerKm = fuelConsumPerKm;
        }
    }
}
