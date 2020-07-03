using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new RecipesDbContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated(); // Ако издаде грешка, да копирам пак адреса на сървъра в конекшън стринга или целия стринг наново.

            //db.Database.Migrate();

            var musaka = new Recipe
            {
                Name = "Musaka",
                Description = "Българска готина манджа с картофи. Пофтариам - българска :D",
                CookingTime = new TimeSpan(1, 15, 8)
            };

            var skembe = new Recipe
            {
                Name = "Skembe",
                Description = "Nice soup",
                CookingTime = new TimeSpan(0, 45, 0),

                Ingredients =
                {
                    new RecipeIngredient
                    {
                        Ingredient = new Ingredient { Name = "Sol", },
                        Quantity = 2
                    },

                    new RecipeIngredient
                    {
                        Ingredient = new Ingredient { Name = "Piper", },
                        Quantity = 3
                    }
                }
            };

            db.Recipes.Add(skembe);
           
            db.SaveChanges();
        }
    }
}
