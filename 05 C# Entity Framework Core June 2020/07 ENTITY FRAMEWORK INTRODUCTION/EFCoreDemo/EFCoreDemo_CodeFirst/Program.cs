using EFCoreDemo_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCoreDemo_CodeFirst
{
    //Добавяне на миграция през Power Shell
    // 1. Трябва да се създаде начална миграция. Ведната след първото генериране на базата.
    // dotnet ef migrations add Initial
    // Като се правят миграции. 
    //Първата миграция създава базата!!! 
    //Базата се създава със прилагането на първата миграция, а не първо да създадеме базата и тогава да направиме първата миграция!

    // НЕ ЗАБРАВЯМЕ ДА СИ ЗАПИШЕМЕ ФАЙЛА ПРЕДИ ПРАВЕНЕТО НА МИГРАЦИЯТА !!!!!

    //2. Добавяме проперти, адваме миграция през Power Shell с ново име и след това трябва да я приложим в кода с db.Database.Migrate().

    class Program
    {
        static void Main(string[] args)
        {
            using var db = new RecipesDbContext();

            //db.Database.Migrate();

            //db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Name = "Musaka" });

            db.Recipes.Add(new Recipe
            {
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
