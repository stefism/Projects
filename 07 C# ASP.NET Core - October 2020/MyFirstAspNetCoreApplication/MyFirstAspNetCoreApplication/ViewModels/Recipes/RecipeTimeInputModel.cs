using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.ViewModels.Recipes
{
    public class RecipeTimeInputModel
    {
        [Range(1, 24 * 60)]
        public int PreparationTime { get; set; }

        [Range(1, 2 * 24 * 60)] //За качествен програмен код е добре да се пишат разписани формулите за да се ориентираме кое какво е.
        public int CookingTime { get; set; }
    }
}
