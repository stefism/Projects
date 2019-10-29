using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 1.6);

            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;

                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
