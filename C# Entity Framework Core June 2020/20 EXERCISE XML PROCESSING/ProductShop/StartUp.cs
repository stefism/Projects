using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
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
            string q05 = GetProductsInRange(db);

            System.Console.WriteLine(q05);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {

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