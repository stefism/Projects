using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();

            List<Engine> engines = new List<Engine>();
            List<Tire[]> tires = new List<Tire[]>();

            string tiresInfo = Console.ReadLine();

            while (tiresInfo != "No more tires")
            {
                double[] currentTiresInfo = tiresInfo.Split().Select(double.Parse).ToArray();

                Tire[] currentTire = new Tire[4];

                for (int i = 0; i < currentTiresInfo.Length; i+=2)
                {
                    int year = (int)currentTiresInfo[i];
                    double currentPressure = currentTiresInfo[i + 1];

                    Tire tire = new Tire(year, currentPressure);

                    currentTire[i/2] = tire;
                }

                tires.Add(currentTire);

                tiresInfo = Console.ReadLine();
            }

            string engineInfo = Console.ReadLine();

            while (engineInfo != "Engines done")
            {
                string[] currentEngine = engineInfo.Split();

                int horsePower = int.Parse(currentEngine[0]);
                double cubicCapacity = double.Parse(currentEngine[1]);

                Engine currentEngineInfo = new Engine(horsePower, cubicCapacity);
                engines.Add(currentEngineInfo);

                engineInfo = Console.ReadLine();
            }

            string carInformation = Console.ReadLine();

            while (carInformation != "Show special")
            {
                string[] currentCarInfo = carInformation.Split();

                string make = currentCarInfo[0];
                string model = currentCarInfo[1];
                int year = int.Parse(currentCarInfo[2]);
                double fuelQuantity = double.Parse(currentCarInfo[3]);
                double fuelConsumption = double.Parse(currentCarInfo[4]);
                int engineIndex = int.Parse(currentCarInfo[5]);
                int tiresIndex = int.Parse(currentCarInfo[6]);

                Car currentCar = new Car();

                currentCar.Make = make;
                currentCar.Model = model;
                currentCar.Year = year;
                currentCar.FuelQuantity = fuelQuantity;
                currentCar.FuelConsumption = fuelConsumption;
                currentCar.Tire = tires[tiresIndex];
                currentCar.Engine = engines[engineIndex];

                carsList.Add(currentCar);

                carInformation = Console.ReadLine();
            }

            List<Car> specialCars = new List<Car>();

            Func<List<Car>, bool> pressure = carList =>
            {
                foreach (var car in carList)
                {
                    double pressureSum = 0;

                    foreach (var tire in car.Tire)
                    {
                        pressureSum += tire.Pressure;
                    }

                    if (pressureSum >= 9 && pressureSum <= 10)
                    {
                        return true;
                    }
                }

                return false;
            };

            //specialCars = carsList
            //    .Where(year => year.Year >= 2017)
            //    .Where(hp => hp.Engine.HorsePower >= 330)
            //    .Select(x => x.Tire.Where(y => pressure(y.Pressure)))
            //    .ToList();

            carsList = carsList
                .Where(year => year.Year >= 2017)
                .Where(hp => hp.Engine.HorsePower >= 330)
                .ToList();

            foreach (var car in carsList)
            {
                double pressureSum = 0;

                foreach (var tire in car.Tire)
                {
                    pressureSum += tire.Pressure;
                }

                if (pressureSum >= 9 && pressureSum <= 10)
                {
                    specialCars.Add(car);
                }
            }

            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
