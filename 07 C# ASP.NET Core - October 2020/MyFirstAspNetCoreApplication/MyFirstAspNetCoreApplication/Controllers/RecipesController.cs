using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.ViewModels.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    public class RecipeTimeInputModel
    {
        [Range(1, 24 * 60)]
        public int PreparationTime { get; set; }

        [Range(1, 2 * 24 * 60)] //За качествен програмен код е добре да се пишат разписани формулите за да се ориентираме кое какво е.
        public int CookingTime { get; set; }      
    }   

    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            MinYear = minYear;
            ErrorMessage = $"Value should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is int intValue) //Ако value е int го записва в променливата intValue.
            {
                if (intValue <= DateTime.UtcNow.Year && intValue >= MinYear)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class ValidationWithService : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.GetService<ServiceName>();
            //Можем да ползваме сървиз който имаме и да го ползваме за валидация. Базата данни също можем за ползваме.
            
            return new ValidationResult("");
        }
    }
  
    public class RecipesController : Controller
    {
        public IActionResult Add(AddRecipeInputModel input)
        {
            //Атрибута [FromBody] указан преди името на параметъра в конструктора, ни позволява да прочетем от бодито на заявката нещото, когато то е Json.
            //[Bind "<Param1>, <Param2>, ...."] указваме точно кои пропертита искаме. Това само ако не искаме да вземе всички пропертита, които се подават, а само някои.

            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            return Json(input);
        }
    }
}
