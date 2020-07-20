using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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

            //var workingDirectory = Environment.CurrentDirectory;
            //var fileDirectory = Directory.GetParent(workingDirectory).Parent.Parent;
            //var inputFile = File.ReadAllText($"{fileDirectory}\\Datasets\\categories-products.json");

            string output = GetUsersWithProducts(db);
            Console.WriteLine(output);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        //Query 08.	  Export Users and Products
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count())
                .Select(u => new
                {
                    UsersCount = context.Users.Count(),
                    Users = new 
                    {
                        u.LastName,
                        u.Age,
                        SoldProducts = u.ProductsSold.Select(ps => new
                        {
                            Count = u.ProductsSold.Count(),
                            Products = u.ProductsSold.Select(pss => new
                            {
                                pss.Name,
                                pss.Price
                            })
                        })
                    }                    
                }).ToList();
                
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

                NullValueHandling = NullValueHandling.Ignore,

                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(users, settings);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        //Query 07.   Export Categories by Products Count
        {
            var category = context.Categories
                .OrderByDescending(cp => cp.CategoryProducts.Select(c => c.Product).Count())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Select(cp => 
                                                    cp.Product).Count(),
                    AveragePrice = c.CategoryProducts.Select(cp =>
                                                 cp.Product.Price).Average().ToString("F2"),
                    TotalRevenue = c.CategoryProducts.Select(cp =>
                                                 cp.Product.Price).Sum().ToString("F2")
                }).ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(category, settings);

            return json;
        }

        public static string GetSoldProducts100(ProductShopContext context)
        {
            var usersSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                 .Select(u => new
                 {
                     u.FirstName,
                     u.LastName,
                     SoldProducts = u.ProductsSold
                     .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                 }).ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(usersSoldProducts, settings);

            return json;

        }

        public static string GetSoldProducts(ProductShopContext context)
        // Query 06.	Export Successfully Sold Products
        {
            var usersSoldProducts = context.Users
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .Where(sp => sp.BuyerFirstName != null && sp.BuyerLastName != null)
                })
                 .Where(p => p.SoldProducts.Any(n => n.BuyerFirstName != null && n.BuyerLastName != null))
                 .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(usersSoldProducts, settings);

            return json;
        }

        public static string GetProductsInRange(ProductShopContext context)
        // Query 05.	Export Products in Range
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                }).OrderBy(p => p.Price).ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(productsInRange, settings);

            return json;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        //Query 04. Import Categories and Products
        {
            List<CategoryProduct> categoryProducts = JsonConvert.
                DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
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