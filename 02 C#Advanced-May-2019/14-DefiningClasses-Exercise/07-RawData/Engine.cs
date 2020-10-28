using System;
using System.Collections.Generic;
using System.Text;

namespace _07_RawData
{
    public class Engine
    {
        public double EngineSpeed { get; set; }
        public double EnginePower { get; set; }

        public Engine(double speed, double power)
        {
            EngineSpeed = speed;
            EnginePower = power;
        }
    }
}
