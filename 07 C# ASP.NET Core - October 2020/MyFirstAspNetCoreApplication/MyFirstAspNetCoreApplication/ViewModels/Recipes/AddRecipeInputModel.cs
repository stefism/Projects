using Microsoft.AspNetCore.Http;
using MyFirstAspNetCoreApplication.Controllers;
using MyFirstAspNetCoreApplication.Models;
using MyFirstAspNetCoreApplication.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.ViewModels.Recipes
{
    public class AddRecipeInputModel : IValidatableObject
    {
        [Required(ErrorMessage ="Името е задължително."), MinLength(5, ErrorMessage ="Минималната дължина на името трябва да бъде 5 символа.")] //MinLength винаги трябва да върви с Required атрибута за да работи правилно.
        [Display(Name ="Име на рецептата:")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Описанието е задължително.")]
        [DataType(DataType.MultilineText)] //Ползва се за textarea когато имаме с повече от един ред.
        public string Decription { get; set; }

        public RecipeType Type { get; set; }

        [DataType(DataType.Date)] //Използвай само датата (без часа) от DateTime.
        [Display(Name = "Първо приготвяне:")]
        public DateTime FirstCooked { get; set; }

        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }

        public RecipeTimeInputModel Time { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<IFormFile> Images { get; set; } //За качване на много файлове.

        public string[] Ingredients { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Time.PreparationTime > Time.CookingTime)
            {
                yield return new ValidationResult("Preparation time cannot be more than the cooking time.");
            }

            if (Time.PreparationTime + Time.CookingTime > 2.5 * 24 * 60)
            {
                yield return new ValidationResult("Too much time to cook.");
            }
        }
    }
}
