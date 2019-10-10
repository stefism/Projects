using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine)
            : base(name, price, milliliters)
        {
            Caffeine = caffeine;
            //CoffeePrice = price;
            //CoffeeMilliliters = milliliters;
        }

        public double CoffeeMilliliters { get; set; } = 50;
        public decimal CoffeePrice { get; set; } = 3.50M;
        public double Caffeine { get; set; }
    }
}
