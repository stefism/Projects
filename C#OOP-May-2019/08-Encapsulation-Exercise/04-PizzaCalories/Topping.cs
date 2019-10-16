using System;
using System.Collections.Generic;
using System.Text;

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
        private double topptngWeightInGrams;

        private string ToppingType
        {
            get => toppingType;

            set
            {
                if (value != "meat" || value != "veggies"
                    || value != "cheese" || value != "sauce")
                {
                    throw new InvalidOperationException($"Cannot place {ToppingType} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        private double Weight
        {
            get => topptngWeightInGrams;

            set
            {
                if (value < MIN_TOPPING_GRAMS || value > MAX_TOPPING_GRAMS)
                {
                    throw new InvalidOperationException($"{ToppingType} weight should be in the range [{MIN_TOPPING_GRAMS}..{MAX_TOPPING_GRAMS}].");
                }

                topptngWeightInGrams = value;
            }
        }

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
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
