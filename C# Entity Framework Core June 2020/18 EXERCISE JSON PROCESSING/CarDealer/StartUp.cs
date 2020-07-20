using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var workingDirectory = Environment.CurrentDirectory;
            var fileDirectory = Directory.GetParent(workingDirectory).Parent.Parent;
            var inputFile = File.ReadAllText($"{fileDirectory}\\Datasets\\cars.json");

            string output = ImportCars(db, inputFile);
            Console.WriteLine(output);
        }

        public static string ImportSales
            (CarDealerContext context, string inputJson)
        //Query 13.	Import Sales
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        //Query 12.	Import Customers
        {
            List<Customer> customers = JsonConvert
                .DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        //Query 11.	Import Cars
        {
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        //Query 10.	Import Parts
        {
            List<Part> parts = JsonConvert
                .DeserializeObject<List<Part>>(inputJson);

            var supplierMaxId = context.Suppliers.Select(s => s.Id).Max();

            foreach (var part in parts)
            {
                if (part.SupplierId <= supplierMaxId)
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        //Query 09.	 Import Suppliers
        {
            List<Supplier> suppliers = JsonConvert
                .DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
    }
}