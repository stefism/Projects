using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price = 5, double grams = 250, double calories = 1000)
            :base(name, price, grams, calories)
        {
            Grams = 250;
            Calories = 1000;
            Price = 5;
        }
    }
}
