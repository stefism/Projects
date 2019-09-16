using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Laptop
    {
        public Laptop(string make, string model, double displaySize, decimal price, int ram, int? ssd)
        {
            Make = make;
            Model = model;
            DisplaySize = displaySize;
            Price = price;
            Ram = ram;
            Ssd = ssd;
        }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public double DisplaySize { get; private set; }

        public decimal Price { get; private set; }

        public int Ram { get; private set; }

        public int? Ssd { get; private set; } // int? - nullable int - стойността му може да бъде null

        public string FullInfo()
        {
            return $@"Make: {Make}
                             Model: {Model}
                              Price: {Price:F2}";
        }
    }
}
