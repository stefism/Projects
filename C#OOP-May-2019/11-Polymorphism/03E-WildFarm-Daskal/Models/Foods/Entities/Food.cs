using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_WildFarm_Daskal.Models.Foods.Contracts
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
