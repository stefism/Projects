using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.IOManagement;
using P03_SalesDatabase.IOManagement.Contracts;
using P03_SalesDatabase.Seedind;
using P03_SalesDatabase.Seedind.Contracts;
using System;
using System.Collections.Generic;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var db = new SalesContext();

            Random random = new Random();
            IWriter consoleWriter = new ConsoleWriter();          

            ICollection<ISeeder> seeders = new List<ISeeder>
            {
                new ProductSeeder(db, random, consoleWriter),
                new StoreSeader(db, consoleWriter)
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed();
            }
        }
    }
}
