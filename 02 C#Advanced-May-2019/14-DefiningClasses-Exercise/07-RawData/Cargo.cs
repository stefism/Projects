using System;
using System.Collections.Generic;
using System.Text;

namespace _07_RawData
{
    public class Cargo
    {
        public double CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(double weight, string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }
    }
}
