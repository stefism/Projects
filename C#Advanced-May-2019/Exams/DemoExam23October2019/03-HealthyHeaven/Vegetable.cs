using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public string Name { get; private set; }
        public int Calories { get; private set; }

        public override string ToString()
        {
            return $" - {Name} have {Calories} calories";
        }
    }
}
