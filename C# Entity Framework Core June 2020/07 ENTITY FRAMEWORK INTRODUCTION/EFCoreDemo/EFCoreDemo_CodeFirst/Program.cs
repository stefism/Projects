using EFCoreDemo_CodeFirst.Models;
using System;
using System.Collections.Generic;

namespace EFCoreDemo_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new RecipesDbContext();
            
            db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Name = "Musaka"});

            db.Recipes.Add(new Recipe { 
                Name = "Musaka dve",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient {Name = "Sol", Amount = 0.5},
                    new Ingredient {Name = "Piper", Amount = 0.2}
                }
            }); // Каскадно вмъкване, благодарение на навигационните пропертита.

            db.SaveChanges();
        }
    }
}
