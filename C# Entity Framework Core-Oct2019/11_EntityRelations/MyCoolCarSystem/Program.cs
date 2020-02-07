using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;
using MyCoolCarSystem.Data.Models;
using MyCoolCarSystem.ResultsModels;
using System;
using System.Linq;

namespace MyCoolCarSystem
{
    public class Program
    {
        public static void Main()
        {
            using CarDbContext db = new CarDbContext();

            db.Database.Migrate();

            var result = db.Purchases.Select(p => new PurchaseResultModel
            {
                Price = p.Price,
                PurchaseDate = p.PurchaseDate,

                Customer = new CustomerResultModel
                {
                    Name = p.Customer.FirstName + " " + p.Customer.LastName,
                    Town = p.Customer.Address.Town
                },

                Car = new CarResultModel
                {
                    Make = p.Car.Model.Make.Name,
                    Model = p.Car.Model.Name,
                    Vin = p.Car.Vin
                },
            }).ToList();

            // Не ползваме Select() когато искаме да ъпдейтнеме (модифицираме, истриеме) нещо.

            db.SaveChanges();
        }

        private static void AddAddressToCustomer(CarDbContext db) // 05
        {
            Customer customer = db.Customers.FirstOrDefault();

            customer.Address = new Address
            {
                Text = "Tintyava 15",
                Town = "Sofia"
            };
        }

        private static void AddCustomer(CarDbContext db) // 04
        {
            Car car = db.Cars.FirstOrDefault();

            Customer customer = new Customer
            {
                FirstName = "Ivan",
                LastName = "Peshov",
                Age = 29
            };

            customer.Purchases.Add(new CarPurchase
            {
                Car = car,
                PurchaseDate = DateTime.Now.AddDays(-10),
                Price = car.Price * 0.9m
            });

            db.Customers.Add(customer);
        }

        private static void AddCarToInsigniaModel(CarDbContext db) // 03
        {
            Model insigniaModel = db.Models.FirstOrDefault(m => m.Name == "Insignia");

            insigniaModel.Cars.Add(new Car
            {
                Color = "Black",
                Price = 20_000,
                ProductionDate = DateTime.Now.AddDays(-100),
                Vin = "8989G98D8"
            });

            insigniaModel.Cars.Add(new Car
            {
                Color = "White",
                Price = 25000,
                ProductionDate = DateTime.Now.AddDays(-200),
                Vin = "hgj87klly"
            });

            insigniaModel.Cars.Add(new Car
            {
                Color = "Orange",
                Price = 18000,
                ProductionDate = DateTime.Now.AddDays(-300),
                Vin = "K08JJF54"
            });
        }

        private static void AddModelsToOpel(CarDbContext db) // 02
        {
            Make opelMake = db.Makes.FirstOrDefault(m => m.Name == "Opel");

            opelMake.Models.Add(new Model
            {
                Name = "Astra",
                Year = 2017,
                Modification = "OPC"
            });

            opelMake.Models.Add(new Model
            {
                Name = "Insignia",
                Year = 2019,
                Modification = "2.2 TDI"
            });
        }

        private static void AddMakes(CarDbContext db) // 01
        {
            db.Makes.Add(new Make
            {
                Name = "Mercedes"
            });

            db.Makes.Add(new Make
            {
                Name = "BMV"
            });

            db.Makes.Add(new Make
            {
                Name = "Audi"
            });

            db.Makes.Add(new Make
            {
                Name = "Opel"
            });

            db.Makes.Add(new Make
            {
                Name = "Peugeot"
            });
        }
    }
}
