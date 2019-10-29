using _03E_WildFarm_Daskal.Models.Animals.Contracts;
using _03E_WildFarm_Daskal.Models.Foods.Contracts;
using _03E_WildFarm_Daskal.Exceptions;
using System;
using System.Collections.Generic;

namespace _03E_WildFarm_Daskal.Models.Animals.Entities
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract List<Type> PrefferedFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();
        
        public void Feed(IFood food)
        {
            if (!PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFoodTypeException, GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }
    }
}
