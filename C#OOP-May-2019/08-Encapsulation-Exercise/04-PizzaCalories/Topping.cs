using System;

namespace _04_PizzaCalories
{
    public class Topping
    {
        private const int BASE_CALORIES_PER_GRAM = 2;

        private const int MIN_TOPPING_GRAMS = 1;
        private const int MAX_TOPPING_GRAMS = 50;

        private const double MEAT = 1.2;
        private const double VEGGIES = 0.8;
        private const double CHEESE = 1.1;
        private const double SAUCE = 0.9;

        private string toppingType;
        private double toppingWeightInGrams;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        private string ToppingType
        {
            get => toppingType;

            set
            {
                if (value != "meat" && value != "veggies"
                   && value != "cheese" && value != "sauce")
                {
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                    //String after = before.Substring(0, 1).ToUpper() + before.Substring(1);
                }
                toppingType = value;
            }
        }



        private double Weight
        {
            get => toppingWeightInGrams;

            set
            {
                if (value < MIN_TOPPING_GRAMS || value > MAX_TOPPING_GRAMS)
                {
                    string type = ToppingType.Substring(0, 1).ToUpper() + ToppingType.Substring(1);
                    throw new InvalidOperationException($"{type} weight should be in the range [{MIN_TOPPING_GRAMS}..{MAX_TOPPING_GRAMS}].");
                }

                toppingWeightInGrams = value;
            }
        }

        public double CalculateCalories()
        {
            double modifier = 0;

            switch (toppingType)
            {
                case "meat":
                    modifier = MEAT;
                    break;

                case "veggies":
                    modifier = VEGGIES;
                    break;

                case "cheese":
                    modifier = CHEESE;
                    break;

                case "sauce":
                    modifier = SAUCE;
                    break;
            }

            double calories = (BASE_CALORIES_PER_GRAM * Weight) * modifier;

            return calories;
        }
    }
}
