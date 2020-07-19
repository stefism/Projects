using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var workingDirectory = Environment.CurrentDirectory;
            var fileDirectory = Directory.GetParent(workingDirectory).Parent.Parent;
            var inputFile = File.ReadAllText($"{fileDirectory}\\Datasets\\products.json");

            string output = ImportProducts(db, inputFile);
            Console.WriteLine(output);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
              
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        //Query 03. Import Categories
        {
            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        //Query 02. Import Products
        {
            List<Product> products = JsonConvert
                .DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        //Query 01. Import Users
        {            
            List<User> users = JsonConvert
                .DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}