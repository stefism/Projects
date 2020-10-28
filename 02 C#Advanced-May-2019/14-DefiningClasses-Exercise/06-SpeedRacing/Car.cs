using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0.0;

        public void Drive(double amountOfKm)
        {
            double fuelExpence = amountOfKm * FuelConsumptionPerKilometer;

            if (fuelExpence > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
            else
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= fuelExpence;
            }
        }
    }
}
