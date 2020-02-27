using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    //Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
    //Install-Package Microsoft.EntityFrameworkCore.Tools -v 2.2.0
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //string inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                string result = GetProductsInRange(db);

                Console.WriteLine(result);
            }
        }

        public static string GetProductsInRange(ProductShopContext context) // 05
        {
            string productsInRange
                = JsonConvert
                .SerializeObject(context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                }), Formatting.Indented);

            return productsInRange;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson) // 04
        {
            var categoriesProducts = JsonConvert
                .DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson) // 03 -- Неще да игнорне последния запис, който е нул.
        {
            var categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson) // 02
        {
            var products = JsonConvert
                .DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson) // 01
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}