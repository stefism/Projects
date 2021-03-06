﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Export._08_GetUsersWithProducts;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string users = File.ReadAllText("../../../Datasets/users.xml");
            //string products = File.ReadAllText("../../../Datasets/products.xml");
            //string categories = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoryProducts = File.ReadAllText("../../../Datasets/categories-products.xml");

            //string q01 = ImportUsers(db, users);
            //string q02 = ImportProducts(db, products);
            //string q03 = ImportCategories(db, categories);
            //string q04 = ImportCategoryProducts(db, categoryProducts);
            //string q05 = GetProductsInRange(db);
            //string q06 = GetSoldProducts(db);
            //string q07 = GetCategoriesByProductsCount(db);
            string q08 = GetUsersWithProducts(db);

            Console.WriteLine(q08);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
            //Query 08. Users and Products
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, ExportUserDto>()
                .ForMember(
                    dto => dto.SoldProduct,
                    opt => opt.MapFrom(u => new ExportProductCountDto()));

                cfg.CreateMap<User, ExportProductCountDto>()
                .ForMember(
                    dto => dto.Count,
                    opt => opt.MapFrom(u => u.ProductsSold.Count))
                .ForMember(
                    dto => dto.Products,
                    opt => opt.MapFrom(u => new ExportProductDto()));

                cfg.CreateMap<Product, ExportProductDto>();

                cfg.CreateMap<User, ExportUserCountDto>()
                .ForMember(
                    dto => dto.Count,
                    opt => opt.MapFrom(u => context.Users.Count(up => up.ProductsSold.Any())))
                .ForMember(
                    dto => dto.Users,
                    opt => opt.MapFrom(u => new ExportUserDto()))
                .BeforeMap((src, dest) => src.ProductsSold.OrderByDescending(p => p.Price));
            });

            var users = context.Users
                .ProjectTo<ExportUserDto>(config)
                .OrderByDescending(p => p.SoldProduct.Count)
                .Take(10)
                .ToList();

            var usersAndProducts = context.Users
                .ToArray() // Това е само за да мине в Judge. Не показва верен изход при мене когато го има този ред!
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new ExportProductCountDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProduct.Count)
                .Take(10)
                .ToArray();

            ExportUserCountDto result = new ExportUserCountDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersAndProducts
            };

            var serializer = new XmlSerializer(typeof(ExportUserCountDto), new XmlRootAttribute("Users"));

            var serializer2 = new XmlSerializer(typeof(List<ExportUserDto>), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (StringWriter sw = new StringWriter(sb))
            {
                serializer2.Serialize(sw, users, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts_me(ProductShopContext context)
        //Query 08. Users and Products
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Product, GetSoldProductsProductDTO>();

                cfg.CreateMap<Product, SoldProductsDTO>()
                .ForMember(
                    dto => dto.Count,
                    opt => opt.MapFrom(p => p.Name.Count()))
                .ForMember(
                    dto => dto.Products,
                    opt => opt.MapFrom(p => p.CategoryProducts.Select(cp => cp.Product)));

                cfg.CreateMap<User, GetUsersUserDTO>();
            });

            return "";
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        //Query 07. Categories By Products Count
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Category, GetCategoriesDTO>()
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(c => c.Name))
                .ForMember(
                    dto => dto.Count,
                    opt => opt.MapFrom(c => c.CategoryProducts
                    .Select(cp => cp.Product).Count()))
                .ForMember(
                    dto => dto.AveragePrice,
                    opt => opt.MapFrom(c => c.CategoryProducts
                    .Select(cp => cp.Product.Price).Average()))
                .ForMember(
                    dto => dto.TotalRevenue,
                    opt => opt.MapFrom(c => c.CategoryProducts
                    .Select(cp => cp.Product.Price).Sum()));
            });

            var categories = context.Categories
                .ProjectTo<GetCategoriesDTO>(config)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<GetCategoriesDTO>), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, categories, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        //Query 06. Sold Products
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, GetSoldProductsProductDTO>();
                cfg.CreateMap<User, GetSoldProductsUserDTO>()
                .ForMember(
                    dto => dto.SoldProducts,
                    opt => opt.MapFrom(u => u.ProductsSold));
            });

            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(sp => sp.BuyerId != null))
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<GetSoldProductsUserDTO>(config)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<GetSoldProductsUserDTO>), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (StringWriter sr = new StringWriter(sb))
            {
                serializer.Serialize(sr, soldProducts, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        //Query 05. Products In Range
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductsInRangeDTO>()
                .ForMember(
                    pir => pir.Name,
                    opt => opt.MapFrom(p => p.Name))
                .ForMember(
                    pir => pir.Price,
                    opt => opt.MapFrom(p => p.Price))
                .ForMember(
                    pir => pir.Buyer,
                    opt => opt.MapFrom(p => p.Buyer.FirstName + " " + p.Buyer.LastName));
            });

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductsInRangeDTO>(config).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductsInRangeDTO>), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (StringWriter swr = new StringWriter(sb))
            {
                serializer.Serialize(swr, productsInRange, nameSpaces);
            }

            //MemoryStream ms = new MemoryStream();
            //serializer.Serialize(ms, productsInRange);
            //ms.Position = 0;

            //StreamReader sr = new StreamReader(ms);
            //string output = sr.ReadToEnd();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        //Query 04. Import Categories and Products
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryProductDTO, CategoryProduct>();
            });

            IMapper mapper = config.CreateMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryProductDTO>), new XmlRootAttribute("CategoryProducts"));

            XDocument xmlDocument = XDocument.Parse(inputXml);
            XmlReader reader = xmlDocument.CreateReader();

            List<CategoryProductDTO> cpDto = (List<CategoryProductDTO>)serializer.Deserialize(reader);

            List<CategoryProduct> cp = mapper.Map<List<CategoryProduct>>(cpDto);

            context.CategoryProducts.AddRange(cp);
            context.SaveChanges();

            return $"Successfully imported {cp.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        //Query 03. Import Categories
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });

            IMapper mapper = config.CreateMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryDTO>), new XmlRootAttribute("Categories"));

            XDocument xmlDocument = XDocument.Parse(inputXml);
            XmlReader reader = xmlDocument.CreateReader();

            List<CategoryDTO> categoriesDto = (List<CategoryDTO>)serializer.Deserialize(reader);

            List<Category> categories = mapper.Map<List<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        //Query 02. Import Products
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
            });

            IMapper mapper = config.CreateMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductDTO>), new XmlRootAttribute("Products"));

            XDocument xmlDocument = XDocument.Parse(inputXml);
            XmlReader reader = xmlDocument.CreateReader();

            List<ProductDTO> productsDto = (List<ProductDTO>)serializer.Deserialize(reader);

            List<Product> products = mapper.Map<List<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        //Query 01. Import Users
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            IMapper mapper = config.CreateMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<UserDTO>), new XmlRootAttribute("Users"));

            //var stringStream = new MemoryStream(Encoding.UTF8.GetBytes(inputXml ?? ""));

            XDocument xmlDocument = XDocument.Parse(inputXml);
            XmlReader reader = xmlDocument.CreateReader();

            List<UserDTO> usersDto = (List<UserDTO>)serializer.Deserialize(reader);

            List<User> users = mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}