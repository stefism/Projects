using System;
using System.Collections.Generic;
using System.Text;

namespace _04_PizzaCalories
{
    public class Pizza
    {
        private const int MAX_NAME_LENGHT = 15;
        private const int MIN_NAME_LENGHT = 15;

        private Dough dough;
        private Topping toppings;
        private string name;

        public Pizza(string name)
        {
            Name = name;
        }

        public string Name 
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_NAME_LENGHT)
                {
                    throw new InvalidOperationException($"Pizza name should be between {MIN_NAME_LENGHT} and {MAX_NAME_LENGHT} symbols.");
                }

                name = value;
            }
        }

        public int NumberOfToppings {get; private set; }
        public double TotalCalories { get; private set; }

        public void CalculateDoughCalories(string type, string technics, double grams)
        {
            Dough dough = new Dough(type, technics, grams);

            TotalCalories += dough.CalulateCalories();
        }

        public void CalculateToppingsCalories(string type, double grams)
        {
            Topping topping = new Topping(type, grams);

            TotalCalories += topping.CalculateCalories();

            if (NumberOfToppings > 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            NumberOfToppings++;
        }
    }
}
