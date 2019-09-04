using System;
using System.Collections.Generic;
using System.Text;

namespace _08_CarSaleman
{
    public class Engine
    {
        public string Model { get; set; }
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, double power, double displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public Engine(string model, double power, string efficiency)
        {
            Model = model;
            Power = power;
            Efficiency = efficiency;
        }

        public Engine(string model, double power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, double power, double displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }
    }
}
