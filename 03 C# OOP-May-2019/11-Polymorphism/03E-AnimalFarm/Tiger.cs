using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void IncreaseWeight(double quantity)
        {
            Weight += quantity * 1.00;
            FoodEaten += (int)quantity;
        }
    }
}
