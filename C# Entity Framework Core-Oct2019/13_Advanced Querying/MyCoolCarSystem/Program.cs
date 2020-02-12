using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;
using MyCoolCarSystem.Data.Models;
using MyCoolCarSystem.ResultsModels;
using System;
using System.Linq;

namespace MyCoolCarSystem
{
    public class Program
    {
        public static void Main()
        {
            using CarDbContext db = new CarDbContext();

            db.Database.Migrate();

            int price = 5000;

            var result = db.Cars.Where(c => c.Price > price).ToList();

            var result2 = db.Cars
                .FromSqlInterpolated($"SELECT * FROM Cars WHERE Price > {price}")
                .ToList(); 
            // Директно се пише SQL заявка без риск от SQL Injection
            // Работи с последна версия на EF Core. Със 2.2.0 не работи!

            db.SaveChanges();
        }
    }
}
