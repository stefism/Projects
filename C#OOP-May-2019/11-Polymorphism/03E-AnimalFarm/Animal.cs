using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public virtual void IncreaseWeight(double quantity)
        {

        }
    }
}
