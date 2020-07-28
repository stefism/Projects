using RealEstates.Data;
using System;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
