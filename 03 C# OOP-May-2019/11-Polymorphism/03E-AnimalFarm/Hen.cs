using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override void IncreaseWeight(double quantity)
        {
            Weight += quantity * 0.35;
            FoodEaten += (int)quantity;
        }
    }
}
