using System;
using System.Collections.Generic;
using System.Text;

namespace _07_RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public Car()
        {
            Tires[0].TireAge = 0.0;
            Tires[0].TirePressure = 0.0;

            Tires[1].TireAge = 0.0;
            Tires[1].TirePressure = 0.0;

            Tires[2].TireAge = 0.0;
            Tires[2].TirePressure = 0.0;

            Tires[3].TireAge = 0.0;
            Tires[3].TirePressure = 0.0;
        }
    }
}
