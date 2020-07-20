using ProductShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop
{
    public class Proba
    {
        public static void pro()
        {
            var db = new ProductShopContext();
        }
        
        public static string GetUsersWithProducts_me(ProductShopContext context)
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
                        Age = u.Age,
                        SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(ps => new
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
}
