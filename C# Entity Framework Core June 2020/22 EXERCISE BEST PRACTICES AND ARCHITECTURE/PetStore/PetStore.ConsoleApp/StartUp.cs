using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using System;

namespace PetStore.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new PetStoreDbContext();
            db.Database.Migrate();
        }
    }
}
