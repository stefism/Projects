﻿using System;

namespace _01E_Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            double fuelQuantity = double.Parse(input[1]);
            double literPerKmConsumpt = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            Vehicle car = new Car(fuelQuantity, literPerKmConsumpt, tankCapacity);

            input = Console.ReadLine().Split();

            fuelQuantity = double.Parse(input[1]);
            literPerKmConsumpt = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Vehicle truck = new Truck(fuelQuantity, literPerKmConsumpt, tankCapacity);

            input = Console.ReadLine().Split();

            fuelQuantity = double.Parse(input[1]);
            literPerKmConsumpt = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Bus bus = new Bus(fuelQuantity, literPerKmConsumpt, tankCapacity);

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                input = Console.ReadLine().Split();

                string command = input[0];
                string vehicleType = input[1];
                double distanceOrLiters = double.Parse(input[2]);

                switch (command)
                {
                    case "Drive":
                        if (vehicleType == "Car")
                        {
                            VehicleDrive(distanceOrLiters, car);
                        }
                        else if (vehicleType == "Truck")
                        {
                            VehicleDrive(distanceOrLiters, truck);
                        }
                        else if (vehicleType == "Bus")
                        {
                            VehicleDrive(distanceOrLiters, bus);
                        }
                        break;

                    case "DriveEmpty":
                        bus.DriveEmpty(distanceOrLiters);
                        break;

                    case "Refuel":
                        if (vehicleType == "Car")
                        {
                            VehicleRefuel(distanceOrLiters, car);
                        }
                        else if (vehicleType == "Truck")
                        {
                            VehicleRefuel(distanceOrLiters, truck);
                        }
                        else if (vehicleType == "Bus")
                        {
                            VehicleRefuel(distanceOrLiters, bus);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        static void VehicleRefuel(double liters, Vehicle vehicle)
        {
            vehicle.Refuel(liters);
        }

        static void VehicleDrive(double distance, Vehicle vehicle)
        {
            vehicle.Drive(distance);
        }
    }
}
