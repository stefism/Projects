using System;
using System.Collections.Generic;
using System.Text;

namespace _07_RawData
{
    public class Tire
    {
        public double TireAge { get; set; }
        public double TirePressure { get; set; }

        public Tire()
        {
            TireAge = 0;
            TirePressure = 0.0;
        }

        public Tire(double age, double pressure)
        {
            TireAge = age;
            TirePressure = pressure;
        }
    }
}
