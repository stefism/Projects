using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void IncreaseWeight(double quantity)
        {
            Weight += quantity * 0.10;
            FoodEaten += (int)quantity;
        }
    }
}
