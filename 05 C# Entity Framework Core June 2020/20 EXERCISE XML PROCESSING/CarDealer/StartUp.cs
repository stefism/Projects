using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.QueryableExtensions.Impl;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string parts = File.ReadAllText("../../../Datasets/parts.xml");
            //string cars = File.ReadAllText("../../../Datasets/cars.xml");
            //string customers = File.ReadAllText("../../../Datasets/customers.xml");
            //string sales = File.ReadAllText("../../../Datasets/sales.xml");

            //string q09 = ImportSuppliers(db, suppliers);
            //string q10 = ImportParts(db, parts);
            //string q11 = ImportCars(db, cars);
            //string q12 = ImportCustomers(db, customers);
            //string q13 = ImportSales(db, sales);
            //string q14 = GetCarsWithDistance(db);
            //string q15 = GetCarsFromMakeBmw(db);
            string q16 = GetLocalSuppliers(db);
            //string q17 = GetCarsWithTheirListOfParts(db);
            //string q18 = GetTotalSalesByCustomer(db);
            //string q19 = GetSalesWithAppliedDiscount(db);


            System.Console.WriteLine(q16);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        //Query 19. Sales with Applied Discount
        {
            #region sales
            var sales = context.Sales
                .Select(s => new SalesWithDiscountDto
                {
                    Car = new SalesWithDiscount_CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount =
                       s.Car.PartCars.Sum(pc => pc.Part.Price)
                    - s.Car.PartCars.Sum(pc => pc.Part.Price)
                    * s.Discount / 100
                    //PriceWithDiscount = s.Car.PartCars
                    //.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100)
                }).ToList();
            #endregion

            var serializer = new XmlSerializer(typeof(List<SalesWithDiscountDto>), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, sales, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        //Query 18. Total Sales by Customer
        {
            //var cust = context.Customers
            //    .Select(c => new CustomerDto
            //    {
            //        Customers = new List<CustomerCustomerDto>
            //        {
            //            new CustomerCustomerDto
            //            {
            //                FullName = c.Name,
            //                BoughtCars = c.Sales.Select(s => s.Car).Count(),
            //                SpentMoney = c.Sales.SelectMany(x => x.Car.PartCars.Select(x => x.Part.Price)).Sum()
            //            }
            //        }
            //    }).ToList();

            var customers = context.Customers
                .Select(c => new CustomerCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Select(s => s.Car).Count(),
                    SpentMoney = c.Sales.SelectMany(x => x.Car.PartCars.Select(x => x.Part.Price)).Sum()
                }).Where(c => c.BoughtCars > 0)
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<CustomerCustomerDto>), new XmlRootAttribute("customers"));
            
            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, customers, nameSpaces);
            }

            return sb.ToString().TrimEnd();

            //var customers = context.Customers
            //    .Select(c => new CustomerCustomerDto
            //    {
            //        FullName = c.Name,
            //        BoughtCars = c.Sales.Select(s => s.Car).Count(),
            //        SpentMoney = c.Sales.SelectMany(x => x.Car.PartCars.Select(x => x.Part.Price)).Sum()
            //    });            
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = $"{p.Part.Price:F2}"
                        })
                        .ToList()
                })
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts_me(CarDealerContext context)
        //Query 17. Cars with Their List of Parts
        {
            #region cars
            var cars = context.Cars
                .Select(c => new CarWithpartsCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance,

                    //Parts = new CarWithPartsPartDto 
                    //{
                    //    Name = c.PartCars.Select(pc => pc.Part.Name)
                    //} // Не работи така!

                    Parts = c.PartCars
                    .Select(pc => new CarWithPartsPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    }).OrderByDescending(pc => pc.Price)
                    .ToList()
                }).OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();
            #endregion

            var serializer = new XmlSerializer(typeof(List<CarWithpartsCarDto>), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        //Query 16. Local Suppliers
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                }).ToList();

            var serializer = new XmlSerializer(typeof(List<LocalSuppliersDto>), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, suppliers, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        //Query 15. Cars from make BMW
        {
            var cfg = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Car, CarMakeBmwDto>();
            });

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<CarMakeBmwDto>(cfg)
                .AsEnumerable()
                .OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<CarMakeBmwDto>), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        //Query 14. Cars With Distance
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Car, GetCarWithDistanceDto>();
            });

            var mapper = config.CreateMapper();

            var cars = context.Cars
                .ProjectTo<GetCarWithDistanceDto>(config)
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c =>c.Make).ThenBy(c => c.Model)
                .Take(10).ToList();

            var serializer = new XmlSerializer(typeof(List<GetCarWithDistanceDto>), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        //Query 13. Import Sales
        {
            var cfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportSalesDto, Sale>();
            });

            var mapper = cfg.CreateMapper();

            var serializer = new XmlSerializer(typeof(List<ImportSalesDto>), new XmlRootAttribute("Sales"));

            var xmlDoc = XDocument.Parse(inputXml);
            var reader = xmlDoc.CreateReader();

            List<ImportSalesDto> salesDtos = (List<ImportSalesDto>)serializer.Deserialize(reader);

            List<int> carsId = context.Cars.Select(c => c.Id).ToList();

            List<Sale> sales = mapper.Map<List<Sale>>(salesDtos)

            .Where(s => carsId.Contains(s.CarId)).ToList();

            //.Where(s => context.Cars.Any(c => c.Id == s.CarId)); Така явно не работи!

            //List<Part> partsList = partsDto
            // .Where(dto => context.Suppliers
            //               .Any(s => s.Id == dto.SupplierId))

            List<Sale> pr = new List<Sale>();

            foreach (var sale in sales)
            {
                if (carsId.Contains(sale.CarId))
                {
                    pr.Add(sale);
                }
            }

            context.Sales.AddRange(pr);
            context.SaveChanges();

            return $"Successfully imported {pr.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        //Query 12. Import Customers
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportCustomerDto, Customer>();
            });

            var mapper = config.CreateMapper();

            var serializer = new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));

            var xmlDoc = XDocument.Parse(inputXml);
            var reader = xmlDoc.CreateReader();

            List<ImportCustomerDto> customersDtos = (List<ImportCustomerDto>)serializer.Deserialize(reader);

            List<Customer> customers = mapper.Map<List<Customer>>(customersDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars_v2(CarDealerContext context, string inputXml)
        //Query 11. Import Cars
        {
            var serializer = new XmlSerializer(typeof(List<ImportCarsDto>), new XmlRootAttribute("Cars"));

            var xmlDocument = XDocument.Parse(inputXml);
            var reader = xmlDocument.CreateReader();

            List<ImportCarsDto> carsDtos = (List<ImportCarsDto>)serializer.Deserialize(reader);

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDtos)
            {
                int[] uniqueParts = carDto.Parts
                    .Select(p => p.Id).Distinct().ToArray();
                IEnumerable<int> realParts = uniqueParts
                    .Where(id => context.Parts.Any(Part => Part.Id == id));

                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(realPartId => new PartCar
                    {
                        PartId = realPartId // int
                    })
                    .ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        //Query 11. Import Cars
        {
            var serializer = new XmlSerializer(typeof(List<ImportCarsDto>), new XmlRootAttribute("Cars"));

            var xmlDocument = XDocument.Parse(inputXml);
            var reader = xmlDocument.CreateReader();

            List<ImportCarsDto> carsDtos = (List<ImportCarsDto>)serializer.Deserialize(reader);

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var carDto in carsDtos)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                var parts = carDto.Parts
                    .Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                    .Select(p => p.Id).Distinct();

                foreach (var partId in parts)
                {
                    PartCar partCar = new PartCar
                    {
                        PartId = partId,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        //Query 10. Import Parts
        {
            var config = new MapperConfiguration(cfg =>
            { cfg.CreateMap<PartsDto, Part>(); });

            var mapper = config.CreateMapper();

            var serializer = new XmlSerializer(typeof(List<PartsDto>), new XmlRootAttribute("Parts"));

            var xmlDocument = XDocument.Parse(inputXml);
            var reader = xmlDocument.CreateReader();

            var partsDto = (List<PartsDto>)serializer.Deserialize(reader);

            var suppliersId = context.Suppliers
                .Select(s => s.Id).ToList();

            //Без ауто мапер.
            List<Part> partsList = partsDto
                .Where(dto => context.Suppliers
                               .Any(s => s.Id == dto.SupplierId)) // Тука този ред замества по-долу моята филтрация. Бърка в context.Suppliers и казва, има ли някой SupplierId който да съвпада с dto.SupplierId и взима само тях.
                .Select(dto => new Part
                {
                    Name /* Part.name */ = dto.Name, /* PartsDto.name */
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                }).ToList();
            // -----

            // Със ауто мапер
            var parts = mapper.Map<List<Part>>(partsDto);
            //--

            int partsCount = 0;

            foreach (var part in parts)
            {
                if (suppliersId.Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                    partsCount++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {partsCount}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        //Query 09. Import Suppliers
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierDto, Supplier>();
            });

            IMapper mapper = config.CreateMapper();

            var serializer = new XmlSerializer(typeof(List<SupplierDto>), new XmlRootAttribute("Suppliers"));

            var xmlDocument = XDocument.Parse(inputXml);
            var reader = xmlDocument.CreateReader();

            List<SupplierDto> suppliersDto = (List<SupplierDto>)serializer.Deserialize(reader);

            //Без ауто мапер
            List<Supplier> suppliersList = suppliersDto.Select(s => new Supplier
            {
                Name = s.Name,
                IsImporter = s.IsImporter
            }).ToList();
            // ----


            //Със ауто мапер
            var suppliers = mapper.Map<List<Supplier>>(suppliersDto);
            // ----

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}