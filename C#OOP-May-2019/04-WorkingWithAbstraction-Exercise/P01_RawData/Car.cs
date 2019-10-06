using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed,  int enginePower, 
            int cargoWeight, string cargoType, params Tire[] tires)
        {
            Model = model;
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
            CargoWeight = cargoWeight;
            CargoType = cargoType;
            Tires = tires;
        }
        public string Model { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Tire[] Tires { get; set; }
    }
}
