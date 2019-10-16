using System;

namespace _04_PizzaCalories
{
    public class Engine
    {

        public void Run()
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string pizzaName = pizzaArgs[1];
                string pizzaToLower = pizzaName.ToLower();

                Pizza pizza = new Pizza(pizzaToLower);

                string[] doughArgs = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string doughType = doughArgs[1];
                string doughBakingTechnics = doughArgs[2];
                double doughGrams = double.Parse(doughArgs[3]);

                pizza.CalculateDoughCalories(doughType, doughBakingTechnics, doughGrams);

                while (true)
                {
                    string[] toppingArgs = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (toppingArgs[0] == "end")
                    {
                        break;
                    }

                    string toppingType = toppingArgs[1];
                    double toppingGrams = double.Parse(toppingArgs[2]);

                    pizza.CalculateToppingsCalories(toppingType, toppingGrams);
                }

                pizzaToLower = pizzaToLower.Substring(0, 1).ToUpper() + pizzaToLower.Substring(1);

                Console.WriteLine($"{pizzaToLower} - {pizza.TotalCalories:F2} Calories.");
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentException arEx)
            {
                Console.WriteLine(arEx.Message);
            }
        }
    }
}
