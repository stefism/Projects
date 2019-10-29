using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public class Bus: Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 1.4);
            CalculateQuantity(distance, fuelNeed);
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeed = distance * FuelConsumption;
            CalculateQuantity(distance, fuelNeed);
        }

        private void CalculateQuantity(double distance, double fuelNeed)
        {
            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;

                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
}
