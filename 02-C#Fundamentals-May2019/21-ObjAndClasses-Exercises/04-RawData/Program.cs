using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Cars> allCars = new List<Cars>();

            for (int i = 0; i < numberOfCars; i++)
            {
                List<string> currentCarInfo = Console.ReadLine().Split().ToList();

                string carModel = currentCarInfo[0];
                double engineSpeed = double.Parse(currentCarInfo[1]);
                double enginePower = double.Parse(currentCarInfo[2]);
                double cargoWeight = double.Parse(currentCarInfo[3]);
                string cargoType = currentCarInfo[4];

                Cars currentCar = new Cars(carModel, engineSpeed, enginePower, cargoWeight, cargoType);

                allCars.Add(currentCar);
            }

            string cargo = Console.ReadLine();

            foreach (var item in allCars)
            {
                if (cargo == "fragile")
                {
                    if (item.CargoType == "fragile" && item.CargoWeight < 1000)
                    {
                        Console.WriteLine(item.Model);
                    }
                }
                else
                {
                    if (item.CargoType == "flamable" && item.EnginePower > 250)
                    {
                        Console.WriteLine(item.Model);
                    }
                }
            }

        }
    }
    class Cars
    {
        public string Model { get; set; }
        public double EngineSpeed { get; set; }
        public double EnginePower { get; set; }
        public double CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cars(string model, double engineSpeed, double enginePower, double cargoWeght, string cargoType)
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeght;
            this.CargoType = cargoType;

        }
    }
}
