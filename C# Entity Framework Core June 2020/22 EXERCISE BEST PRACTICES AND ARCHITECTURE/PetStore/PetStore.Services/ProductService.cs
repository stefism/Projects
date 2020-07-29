using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Contracts;
using PetStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductViewModel product)
        {
            Product productModel = mapper.Map<Product>(product);
            dbContext.Products.Add(productModel);
            dbContext.SaveChanges();
        }

        public ICollection<ListAllProductByTypeViewModel> ListAllByProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException();
            }

            var allProducts = dbContext.Products
                    .Where(p => p.ProductType == productType)
                    .ProjectTo<ListAllProductByTypeViewModel>(mapper.ConfigurationProvider).ToList();

            return allProducts;
        }

        public ICollection<ListAllProductsViewModel> GetAllProducts()
        {
            var allProducts = dbContext.Products
                .ProjectTo<ListAllProductsViewModel>(mapper.ConfigurationProvider).ToList();

            return allProducts;
        }

        public string RemoveProductByName(string name)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return "Product with this name is not found.";
            }

            product.IsRemoved = true;
            dbContext.SaveChanges();

            return $"Product {name} removed successfully.";
        }
    }
}
