using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_SpecialCars_v2
{
    public class Tire
    {
        public int Year { get; set; }
        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
    }

    public class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tire { get; set; }

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tire = tires;

        }

        public void Drive(double distance)
        {
            double expenceFuel = distance * (FuelConsumption / 100);

            if (expenceFuel > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= distance * (FuelConsumption / 100);
            }
        }

        public string WhoAmI()
        {
            string output = $"Make: {Make}{Environment.NewLine}Model: {Model}{Environment.NewLine}Year: {Year}{Environment.NewLine}Fuel: {FuelQuantity:F2}L";
            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();

            List<Engine> engines = new List<Engine>();
            List<Tire[]> tires = new List<Tire[]>();

            string tiresInfo = Console.ReadLine();

            while (tiresInfo != "No more tires")
            {
                double[] currentTiresInfo = tiresInfo.Split().Select(double.Parse).ToArray();

                Tire[] currentTire = new Tire[4];

                for (int i = 0; i < currentTiresInfo.Length; i += 2)
                {
                    int year = (int)currentTiresInfo[i];
                    double currentPressure = currentTiresInfo[i + 1];

                    Tire tire = new Tire(year, currentPressure);

                    currentTire[i / 2] = tire;
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

            Func<Car, bool> pressure = car =>
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
                
                return false;
            };

            specialCars = carsList
                .Where(year => year.Year >= 2017)
                .Where(hp => hp.Engine.HorsePower >= 330)
                .Where(x => pressure(x))
                .ToList();

            //carsList = carsList
            //    .Where(year => year.Year >= 2017)
            //    .Where(hp => hp.Engine.HorsePower >= 330)
            //    .ToList();

            //foreach (var car in carsList)
            //{
            //    double pressureSum = 0;

            //    foreach (var tire in car.Tire)
            //    {
            //        pressureSum += tire.Pressure;
            //    }

            //    if (pressureSum >= 9 && pressureSum <= 10)
            //    {
            //        specialCars.Add(car);
            //    }
            //}

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
