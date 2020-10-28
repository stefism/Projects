using _03E_WildFarm_Daskal.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_WildFarm_Daskal.Models.Animals.Entities
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> PrefferedFoodTypes
            => new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit)
            };

        protected override double WeightMultiplier => 0.10;

        public override string AskFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
