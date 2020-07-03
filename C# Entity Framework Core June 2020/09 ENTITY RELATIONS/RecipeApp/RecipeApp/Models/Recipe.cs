using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<RecipeIngredient>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan CookingTime { get; set; } // Пази време като интервал от време.

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
