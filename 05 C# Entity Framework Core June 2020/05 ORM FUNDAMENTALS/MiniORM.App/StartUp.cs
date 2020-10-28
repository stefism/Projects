using System;
using System.Linq;

namespace MiniORM.App
{
    using Data;
    using Data.Entities;
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = DESKTOP-LNP1A21\SQLEXPRESS;Database=SoftUni;Integrated Security=true";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
