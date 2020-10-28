using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo_CodeFirst.Models
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {

        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-LNP1A21\\SQLEXPRESS;Database=Recipes;Integrated Security=true");
            }         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // Това е класа за флуент апи-то.
            base.OnModelCreating(modelBuilder);
        }
    }
}
