using P03_SalesDatabase.Data;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SalesContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
