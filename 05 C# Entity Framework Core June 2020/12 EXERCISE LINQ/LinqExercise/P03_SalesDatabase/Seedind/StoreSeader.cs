using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.IOManagement.Contracts;
using P03_SalesDatabase.Seedind.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_SalesDatabase.Seedind
{
    public class StoreSeader : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public StoreSeader(SalesContext context, IWriter writer)
        {
            dbContext = context;
            this.writer = writer;
        }

        public void Seed()
        {
            Store[] stores = new Store[]
            {
                new Store() {Name = "Store one"},
                new Store() {Name = "Store two"},
                new Store() {Name = "Store 23"},
                new Store() {Name = "Store 56"},
                new Store() {Name = "Store 48"},
            };

            dbContext.Stores.AddRange(stores);
            dbContext.SaveChanges();

            writer.WriteLine($"{stores.Length} added to database.");
        }
    }
}
