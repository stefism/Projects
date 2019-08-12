using System;
using System.Linq;
using System.Collections.Generic;

namespace _06_AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<string> servedCars = new Stack<string>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Service")
                {
                    if (cars.Count > 0)
                    {
                    string currentServedCars = cars.Dequeue();
                    Console.WriteLine($"Vehicle {currentServedCars} got served.");
                    servedCars.Push(currentServedCars);
                    }
                }

                else if (command.StartsWith("CarInfo"))
                {
                    string[] carInfo = command.Split("-");
                    string carModel = carInfo[1];

                    if (cars.Contains(carModel))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }
            }

            if (cars.Count > 0)
            {
            Console.Write("Vehicles for service: ");
            Console.WriteLine(string.Join(", ", cars));
            }

            Console.Write("Served vehicles: ");
            Console.WriteLine(string.Join(", ", servedCars));
        }
    }
}
