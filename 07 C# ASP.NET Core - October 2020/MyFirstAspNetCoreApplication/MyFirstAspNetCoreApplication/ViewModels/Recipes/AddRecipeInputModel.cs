using MyFirstAspNetCoreApplication.Controllers;
using MyFirstAspNetCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.ViewModels.Recipes
{
    public class AddRecipeInputModel
    {
        [Required, MinLength(5)] //MinLength винаги трябва да върви с Required атрибута за да работи правилно.
        public string Name { get; set; }

        [Required]
        public string Decription { get; set; }

        public RecipeType Type { get; set; }

        public DateTime FirsrCooked { get; set; }

        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public string[] Ingredients { get; set; }
    }
}
