using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
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
            string q06 = GetSoldProducts(db);

            System.Console.WriteLine(q06);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        //Query 07. Categories By Products Count
        {
            var config = new MapperConfiguration(cfg => 
            {

            });
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