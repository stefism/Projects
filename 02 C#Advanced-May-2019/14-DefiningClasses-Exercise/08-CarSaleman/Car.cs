using System;
using System.Collections.Generic;
using System.Text;

namespace _08_CarSaleman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, double weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine,  string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, double weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }

        public override string ToString()
        {
            string output = string.Empty;

            output += $"{Model}:{Environment.NewLine}";
            output += $"  {Engine.Model}:{Environment.NewLine}";
            output += $"    Power: {Engine.Power}{Environment.NewLine}";

            if (Engine.Displacement == 0)
            {
                output += $"    Displacement: n/a{Environment.NewLine}";
            }
            else
            {
                output += $"    Displacement: {Engine.Displacement}{Environment.NewLine}";
            }

            if (Engine.Efficiency == null)
            {
                output += $"    Efficiency: n/a{Environment.NewLine}";
            }
            else
            {
                output += $"    Efficiency: {Engine.Efficiency}{Environment.NewLine}";
            }
            
            if (Weight == 0)
            {
                output += $"  Weight: n/a{Environment.NewLine}";
            }
            else
            {
                output += $"  Weight: {Weight}{Environment.NewLine}";
            }

            if (Color == null)
            {
                output += $"  Color: n/a";
            }
            else
            {
                output += $"  Color: {Color}";
            }
            
            return output;
        }
    }
}
