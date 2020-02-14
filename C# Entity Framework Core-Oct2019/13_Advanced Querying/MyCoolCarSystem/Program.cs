using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;
using MyCoolCarSystem.Data.Models;
using MyCoolCarSystem.ResultsModels;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace MyCoolCarSystem
{
    public class Program
    {
        public static void Main()
        {
            using CarDbContext db = new CarDbContext();

            db.Database.Migrate();

            //Z.EntityFramework.Plus - batch delete and batch update ги прави с оптимизирани заявки към базата.
            
            var cars = db.Cars.Where(c => c.Price > 1000).Delete();

            var cars2 = db.Cars.Where(c => c.Price < 20_000)
                .Update(c => new Car { Price = c.Price * 1.2m }); // Същото иначе:

            db.Cars.Where(c => c.Price < 20_000)
                       .ToList()
                       .ForEach(c => c.Price = c.Price * 1.2m);


            db.SaveChanges();
        }

        private static void SqlInterpolated(CarDbContext db)
        {
            int price = 5000;

            var result = db.Cars.Where(c => c.Price > price).ToList();

            var result2 = db.Cars
                .FromSqlInterpolated($"SELECT * FROM Cars WHERE Price > {price}")
                .ToList();
            // Директно се пише SQL заявка без риск от SQL Injection
            // Работи с последна версия на EF Core. Със 2.2.0 не работи!
        }
    }
}
