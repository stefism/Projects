using System;

namespace _04_PizzaCalories
{
    public class Dough // Тесто
    {
        private const int BASE_CALORIES_PER_GRAM = 2;

        private const double MIN_WEIGHT_IN_GRAMS = 1;
        private const double MAX_WEIGHT_IN_GRAMS = 200;

        private const double WHITE = 1.5;
        private const double WHOLEGRAIN = 1.0;
        private const double CRIPSY = 0.9;
        private const double CHEWY = 1.1;
        private const double HOMEMADE = 1.0;

        private double calories;

        public Dough(string doughType, string bakingTechnics, double grams) //: base()
        {
            Type = doughType;
            BakingTechnic = bakingTechnics;
            WeightInGrams = grams;
        }

        private string type; // Бяло, пълнозърнесто
        private string bakingTechnic; // хрупкаво, дъвчащо, домашно
        private double weightGrams;

        private string Type
        {
            get => type;

            set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new InvalidOperationException("Invalid type of dough.");
                }

                type = value;
            }
        }

        private string BakingTechnic
        {
            get => bakingTechnic;

            set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new InvalidOperationException("Invalid type of dough.");
                }

                bakingTechnic = value;
            }
        }

        private double WeightInGrams
        {
            get => weightGrams;

            set
            {
                if (value < MIN_WEIGHT_IN_GRAMS
                    || value > MAX_WEIGHT_IN_GRAMS)
                {
                    throw new InvalidOperationException
                        ($"Dough weight should be in the range [{MIN_WEIGHT_IN_GRAMS}..{MAX_WEIGHT_IN_GRAMS}].");
                }

                weightGrams = value;
            }
        }

        public double CaloriesPerGram => calories;

        public double CalulateCalories ()
        {
            double doughModifier = 0;
            double bakingModifier = 0;

            switch (Type)
            {
                case "white":
                    doughModifier = WHITE;
                    break;

                case "wholegrain":
                    doughModifier = WHOLEGRAIN;
                    break;
            }

            switch (BakingTechnic)
            {
                case "crispy":
                    bakingModifier = CRIPSY;
                    break;

                case "chewy":
                    bakingModifier = CHEWY;
                    break;

                case "homemade":
                    bakingModifier = HOMEMADE;
                    break;
            }

            calories = (BASE_CALORIES_PER_GRAM * WeightInGrams) 
                * bakingModifier * doughModifier;

            return calories;
        }
    }
}
