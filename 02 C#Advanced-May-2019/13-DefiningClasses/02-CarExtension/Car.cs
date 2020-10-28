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
            double expenceFuel = FuelConsumption * distance / 100;

            if (expenceFuel > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= distance / 100 * FuelConsumption;
            }
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");

            result.AppendLine($"Model: {this.Model}");

            result.AppendLine($"Year: {this.Year}");

            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();

        }
    }
}
