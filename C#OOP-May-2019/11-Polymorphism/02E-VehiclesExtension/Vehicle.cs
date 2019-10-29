using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        protected double TankCapacity 
        {
            get => tankCapacity;
            
            set 
            {
                tankCapacity = value;
            }
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            
            set 
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        protected double FuelConsumption { get; set; }

        public abstract void Drive(double distance);

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else
            {
                if (liters > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    FuelQuantity += liters;
                }
            }
        }
    }
}
