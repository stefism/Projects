using _03E_WildFarm_Daskal.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_WildFarm_Daskal.Models.Animals.Entities
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFoodTypes
            => new List<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => 0.30;

        public override string AskFood()
        {
            return "Meow";
        }
    }
}
