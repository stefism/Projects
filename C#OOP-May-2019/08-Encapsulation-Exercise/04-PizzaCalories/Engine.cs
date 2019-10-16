using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04_PizzaCalories
{
    public class Engine
    {

        public void Run()
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().ToLower().Split();

                string pizzaName = pizzaArgs[1];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughArgs = Console.ReadLine().ToLower().Split();

                string doughType = doughArgs[1];
                string doughBakingTechnics = doughArgs[2];
                double doughGrams = double.Parse(doughArgs[3]);

                pizza.CalculateDoughCalories(doughType, doughBakingTechnics, doughGrams);

                while (true)
                {
                    string[] toppingArgs = Console.ReadLine().ToLower().Split();

                    if (toppingArgs[0] == "end")
                    {
                        break;
                    }

                    string toppingType = toppingArgs[1];
                    double toppingGrams = double.Parse(toppingArgs[2]);

                    pizza.CalculateToppingsCalories(toppingType, toppingGrams);
                }

                Console.WriteLine(pizza.Name);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
