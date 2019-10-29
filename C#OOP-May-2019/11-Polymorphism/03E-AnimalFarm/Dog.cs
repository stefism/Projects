using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void IncreaseWeight(double quantity)
        {
            Weight += quantity * 0.40;
            FoodEaten += (int)quantity;
        }
    }
}
