using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeApp.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Recipes = new HashSet<RecipeIngredient>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]    
        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
