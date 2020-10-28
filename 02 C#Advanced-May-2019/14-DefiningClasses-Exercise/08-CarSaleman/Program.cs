using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_CarSaleman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                AddEngineToList(engines);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                string carEngineModel = carInfo[1];

                Engine modelEngine = engines.First(x => x.Model == carEngineModel);

                AddCarToList(allCars, carInfo, carModel, modelEngine);
            }

            foreach (var car in allCars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void AddCarToList(List<Car> allCars, string[] carInfo, string carModel, Engine modelEngine)
        {
            if (carInfo.Length == 2)
            {
                Car currentCar = new Car(carModel, modelEngine);
                allCars.Add(currentCar);
            }

            else if (carInfo.Length == 3)
            {
                bool isCarWeight = double.TryParse(carInfo[2], out double carWeight);

                if (isCarWeight)
                {
                    Car currentCar = new Car(carModel, modelEngine, carWeight);
                    allCars.Add(currentCar);
                }
                else
                {
                    string carColor = carInfo[2];
                    Car currentCar = new Car(carModel, modelEngine, carColor);
                    allCars.Add(currentCar);
                }
            }

            else if (carInfo.Length == 4)
            {
                double carWeight = double.Parse(carInfo[2]);
                string carColor = carInfo[3];
                Car currentCar = new Car(carModel, modelEngine, carWeight, carColor);
                allCars.Add(currentCar);
            }
        }

        private static void AddEngineToList(List<Engine> engines)
        {
            string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = engineInfo[0];
            double power = double.Parse(engineInfo[1]);

            if (engineInfo.Length == 2)
            {
                Engine currentEngine = new Engine(model, power);
                engines.Add(currentEngine);
            }

            else if (engineInfo.Length == 3)
            {
                bool isDisplacement = double.TryParse(engineInfo[2], out double displacement);

                if (isDisplacement)
                {
                    Engine currentEngine = new Engine(model, power, displacement);
                    engines.Add(currentEngine);
                }
                else
                {
                    string efficiency = engineInfo[2];
                    Engine currentEngine = new Engine(model, power, efficiency);
                    engines.Add(currentEngine);
                }
            }

            else if (engineInfo.Length == 4)
            {
                double displacement = double.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];
                Engine currentEngine = new Engine(model, power, displacement, efficiency);
                engines.Add(currentEngine);
            }
        }
    }
}
