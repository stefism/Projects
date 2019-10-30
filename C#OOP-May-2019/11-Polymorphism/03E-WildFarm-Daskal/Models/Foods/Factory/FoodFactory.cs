using _03E_WildFarm_Daskal.Models.Foods.Contracts;
using _03E_WildFarm_Daskal.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_WildFarm_Daskal.Models.Foods.Factory
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food = null;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
