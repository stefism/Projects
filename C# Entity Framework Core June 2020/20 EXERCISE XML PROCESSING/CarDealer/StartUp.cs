using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.IO;
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
            string parts = File.ReadAllText("../../../Datasets/parts.xml");

            //string q09 = ImportSuppliers(db, suppliers);
            string q10 = ImportParts(db, parts);

            System.Console.WriteLine(q10);
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
            var parts = mapper.Map<List<Part>>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
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

            var suppliersDto = (List<SupplierDto>)serializer.Deserialize(reader);
            var suppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}