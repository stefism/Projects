using P03_SalesDatabase.Data;
using P03_SalesDatabase.Seedind.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Seedind
{
    public class ProductSeeder : ISeeder
    {
        private SalesContext dbContext;

        public ProductSeeder(SalesContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }
    }
}
