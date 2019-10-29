using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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
    }
}
