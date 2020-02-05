using P03_SalesDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using P03_SalesDatabase.Data.Models;
using System.Linq;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        //Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
        //Install-Package Microsoft.EntityFrameworkCore.Tools -v 2.2.0
        public static void Main(string[] args)
        {
            // Когато всичко е готово;
            // 1. Add-Migration Initial
            // 2. Update-Database

            // Преди да качим в джъдж трябва да махнем пакетите, които ни е казано в условието;
            // 1. Uninstall-Package Microsoft.EntityFrameworkCore.Tools -r

            //var db = new SalesContext();

            //using (db)
            //{
            //    int productId = db.Products
            //        .Select(p => p.ProductId).First();

            //    int customerId = db.Customers
            //        .Select(c => c.CustomerId).First();

            //    int storeId = db.Stores
            //        .Select(s => s.StoreId).First();

            //    var sale = new Sale
            //    {
            //        ProductId = productId,
            //        CustomerId = customerId,
            //        StoreId = storeId
            //    };

            //    db.Add(sale);

            //    db.SaveChanges();
            //}
        }
    }
}
