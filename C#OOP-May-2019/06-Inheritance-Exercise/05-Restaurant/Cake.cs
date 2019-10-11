using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
            :base(name, price, grams, calories)
        {
            
        }

        private const double grams = 250;
        private const double calories = 1000;
        private const decimal price = 5m;

    }
}
