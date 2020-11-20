using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.Models;
using System;

namespace MyFirstAspNetCoreApplication.Controllers
{
    //В апи контролерите може да има много методи, но точно кой метод ще се извика зависи не от името на метода, а от типа на заявката (post, get, delete, ect...). Адреса се опрелеля от route, който е написан от горе.

    [Route("[controller]")]
    [ApiController]
    public class ProductsControllerDemo : ControllerBase
    {
        [HttpGet]
        public Product Test(Product product)
        {
            return new Product
            {
                ActiveFrom = DateTime.UtcNow,
                Description = "description",
                Id = 123,
                Name = "Name",
                Price = 123.34,
            };
        }

        [HttpDelete]
        public string SoftUni()
        {
            return "DELETE.";
        }

        [HttpPost]
        public Product SoftUni2(Product product)
        {
            return product;
        }
    }
}
