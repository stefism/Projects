using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 0.9);

            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;
                
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
