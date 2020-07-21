using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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

            //var workingDirectory = Environment.CurrentDirectory;
            //var fileDirectory = Directory.GetParent(workingDirectory).Parent.Parent;
            //var inputFile = File.ReadAllText($"{fileDirectory}\\Datasets\\cars.json");

            string output = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(output);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
            //Query 19.	  Export Sales with Applied Discount
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    customerName = c.Sales.Select(cm => cm.Customer.Name),
                    Discount = c.Sales.Select(s => s.Discount),
                    price = c.PartCars.Select(pc => pc.Part.Price).Sum(),
                    //priceWithDiscount = c.Sales.Select(s => s.Discount) * c.PartCars.Select(pc => pc.Part.Price).Sum()
                }).ToList();

            var cars2 = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount,
                    price = s.Car.PartCars.Select(pc => pc.Part.Price).Sum(),
                    priceWithDiscount = 
                    s.Car.PartCars.Select(pc => pc.Part.Price).Sum() * ((100 - s.Discount == 0 ? 100 : s.Discount) / 100)
                }).ToList();

            return JsonConvert.SerializeObject(cars2, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        //Query 18.	  Export Total Sales by Customer
        {
            var customers = context.Customers
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Select(s => s.Car).Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                }).Where(c => c.BoughtCars >= 1)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //Query 17. 	Export Cars with Their List of Parts
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,                        
                    },
                    parts = c.PartCars
                    .Select(pc => new 
                    {
                        Name = c.PartCars.Select(pcc => pcc.Part.Name),
                        Price = c.PartCars.Select(pcc => pcc.Part.Price.ToString("F2"))
                    })                    
                })
                .ToList();           

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        //Query 16.	Export Local Suppliers
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                }).ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        //Query 15.	Export Cars from Make Toyota
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                }).ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        //Query 14.	Export Ordered Customers
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                }).ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
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