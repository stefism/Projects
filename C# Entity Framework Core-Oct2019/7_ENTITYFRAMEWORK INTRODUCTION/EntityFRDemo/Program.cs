using System;
using System.Linq;
using EntityFRDemo.Data;
using EntityFRDemo.Results;
using Microsoft.EntityFrameworkCore;

namespace EntityFRDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var towns = db.Towns
                    .Select(t => new { t.Name })
                    .ToList();

                //towns.ForEach(t => Console.WriteLine(t.Name));
                //Console.WriteLine(string.Join(Environment.NewLine, towns));

                //---

                var result = db.Employees
                    .Select(e => new EmployeeResultModel
                    {
                        Name = e.FirstName + " " + e.LastName,
                        Department = e.Department.Name
                    })
                    .ToList();

                // Винаги да се ползва селект в заявките и материализацията да е последна!
                // За да има бързодействие.

                //foreach (var employes in result)
                //{
                //    Console.WriteLine(employes.Department + ": " + employes.Name);
                //}

                // Добавяне на нов обект в базата.
                //db.Add(new Town
                //{
                //    Name = "New Town"
                //});

                //db.SaveChanges();

                //Каскадно добавяне в базата
                Town town = new Town { Name = "New Town" };

                town.Addresses.Add(new Addresses { AddressText = "Rio" });

                db.Add(town); // Ще добави както града, така и адреса, който ще го върже за този град.

                db.SaveChanges();

                //Каскадно триене.
                var town3 = db.Towns
                    .Select(t => new
                    {
                        t.TownId,
                        Addresses = t.Addresses.Select(a => a.AddressId)
                    })
                    .FirstOrDefault(t => t.TownId == 33);

                foreach (var address in town3.Addresses)
                {
                    db.Addresses.Remove(new Addresses { AddressId = address });
                }

                db.Towns.Remove(new Town { TownId = town3.TownId });

                db.SaveChanges();
            }
        }
    }
}
