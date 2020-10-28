using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        protected double FuelConsumption { get; set; }
        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
