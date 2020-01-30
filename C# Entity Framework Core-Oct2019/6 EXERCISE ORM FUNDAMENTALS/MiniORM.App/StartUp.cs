using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connString = @"Server=DESKTOP-LNP1A21\SQLEXPRESS;
                                               Database=MiniORM;
                                               Integrated Security=True";

            SoftUniDbContext context = new SoftUniDbContext(connString);

            context.Employees.Add(new Employee
            {
                FirstName = "Prekrasen",
                MiddleName = "Proekt",
                LastName = "Izpisahme",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            Employee employee = context.Employees.Last();
            employee.FirstName = "Strahotno";

            context.SaveChanges();
        }
    }
}
