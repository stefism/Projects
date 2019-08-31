using System;
using System.Collections.Generic;
using System.Text;

namespace _02_CarExtension
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double expenceFuel = FuelConsumption * distance;

            if (expenceFuel > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= distance * FuelConsumption;
            }
        }

        public string WhoAmI()
        {
            string output = $"Make: {Make}{Environment.NewLine}Model: {Model}{Environment.NewLine}Year: {Year}{Environment.NewLine}Fuel: {FuelQuantity:F2}L";
            return output;
        }
    }
}
