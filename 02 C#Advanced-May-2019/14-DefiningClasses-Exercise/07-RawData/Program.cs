using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split();

                string model = currentCarInfo[0];

                double engineSpeed = double.Parse(currentCarInfo[1]);
                double enginePower = double.Parse(currentCarInfo[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                double cargoWeight = double.Parse(currentCarInfo[3]);
                string cargoType = currentCarInfo[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(currentCarInfo[5]);
                double tire1Age = double.Parse(currentCarInfo[6]);

                double tire2Pressure = double.Parse(currentCarInfo[7]);
                double tire2Age = double.Parse(currentCarInfo[8]);

                double tire3Pressure = double.Parse(currentCarInfo[9]);
                double tire3Age = double.Parse(currentCarInfo[10]);

                double tire4Pressure = double.Parse(currentCarInfo[11]);
                double tire4Age = double.Parse(currentCarInfo[12]);

                Tire[] tires = new Tire[4];

                Tire tire1 = new Tire(tire1Age ,tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                tires[0] = tire1;
                tires[1] = tire2;
                tires[2] = tire3;
                tires[3] = tire4;

                Car currentCar = new Car(model, engine, cargo, tires);

                allCars.Add(currentCar);
            }

            string cargoModel = Console.ReadLine();

            if (cargoModel == "fragile")
            {
                foreach (var currentCar in allCars)
                {
                    if (currentCar.Cargo.CargoType == cargoModel)
                    {
                        bool isLowPressure = GetTipePressure(currentCar.Tires);

                        if (isLowPressure)
                        {
                            Console.WriteLine(currentCar.Model);
                        }
                    }
                }
            }
            else if (cargoModel == "flamable")
            {
                foreach (var car in allCars)
                {
                    if (car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }

        static bool GetTipePressure(Tire[] tires)
        {
            foreach (var tire in tires)
            {
                if (tire.TirePressure < 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
