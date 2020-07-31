using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
            string cars = File.ReadAllText("../../../Datasets/cars.xml");

            //string q09 = ImportSuppliers(db, suppliers);
            //string q10 = ImportParts(db, parts);
            string q11 = ImportCars(db, cars);

            System.Console.WriteLine(q11);
        }

        public static string ImportCars_v2(CarDealerContext context, string inputXml)
        //Query 11. Import Cars
        {
            var serializer = new XmlSerializer(typeof(List<ImportCarsDto>), new XmlRootAttribute("Cars"));

            var xmlDocument = XDocument.Parse(inputXml);
            var reader = xmlDocument.CreateReader();

            List<ImportCarsDto> carsDtos = (List<ImportCarsDto>)serializer.Deserialize(reader);

            foreach (var carDto in carsDtos)
            {
                int[] uniqueParts = carDto.Parts
                    .Select(p => p.Id).Distinct().ToArray();
                IEnumerable<int> realParts = uniqueParts
                    .Where(id => context.Parts.Any(Part => Part.Id == id));
            }
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