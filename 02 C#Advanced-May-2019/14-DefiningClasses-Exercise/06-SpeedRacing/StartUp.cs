using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split();

                Car car = new Car();

                string model = currentCarInfo[0];
                double fuelAmount = double.Parse(currentCarInfo[1]);
                double fuelConsFor1Km = double.Parse(currentCarInfo[2]);

                car.Model = model;
                car.FuelAmount = fuelAmount;
                car.FuelConsumptionPerKilometer = fuelConsFor1Km;

                allCars.Add(car);
            }

            string driveInfo = Console.ReadLine();

            while (driveInfo != "End")
            {
                string[] currentDriveInfo = driveInfo.Split();

                string model = currentDriveInfo[1];
                double amountOfKm = double.Parse(currentDriveInfo[2]);

                Car carToDrive = allCars.First(x => x.Model == model);

                carToDrive.Drive(amountOfKm);

                driveInfo = Console.ReadLine();
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
