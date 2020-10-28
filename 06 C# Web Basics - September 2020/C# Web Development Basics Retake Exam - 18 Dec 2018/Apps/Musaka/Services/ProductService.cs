using Microsoft.EntityFrameworkCore.Query.Internal;
using Musaka.Data;
using Musaka.Data.Enums;
using Musaka.ViewModels;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musaka.Services
{
    class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;
        private readonly List<ProductInTableViewModel> allProducts;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
            allProducts = new List<ProductInTableViewModel>();
        }

        public void AddOrder(long barcode, int quantity, string userId)
        {
            Product product = db.Products
                .Where(p => p.Barcode == barcode).FirstOrDefault();

            Receipt receipt;

            if (!db.Receipts.Any(r => r.UserId == userId))
            {
                receipt = new Receipt
                {
                    IssuedOn = DateTime.UtcNow,
                    UserId = userId
                };
            }
            else
            {
                receipt = db.Receipts.FirstOrDefault(r => r.UserId == userId);
            }

            var order = new Order
            {
                Status = Status.Active,
                Product = product,
                Quantity = quantity,
                UserId = userId,
                Receipt = receipt
            };

            db.Orders.Add(order);
            db.SaveChanges();
        }

        public ProductWithSumViewModel ShowOrders(string userId)
        {        
            var orderedProducts = db.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new ProductInTableViewModel
                {
                    Name = o.Product.Name,
                    Quantity = o.Quantity,
                    Price = o.Quantity * o.Product.Price
                }).ToList();

            decimal sum = 0;

            foreach (var product in orderedProducts)
            {
                sum += product.Price;
            }

            var pr = new ProductWithSumViewModel
            {
                TotalSum = sum,
                Products = orderedProducts
            };

            return pr;
        }

        public void CreateProduct(CreateProductInputModel inputModel)
        {
            var product = new Product
            {
                Name = inputModel.Name,
                Picture = inputModel.Picture,
                Price = inputModel.Price,
                Barcode = inputModel.Barcode
            };

            db.Products.Add(product);
            db.SaveChanges();
        }

        public ICollection<AllProductsViewModel> ShowAllProducts()
        {
            var trips = db.Products.Select(p => new AllProductsViewModel
            {
                Name = p.Name,
                Picture = p.Picture,
                Price = p.Price,
                Barcode = p.Barcode
            }).ToList();

            return trips;
        }
    }
}
