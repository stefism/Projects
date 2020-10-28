using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-LNP1A21\SQLEXPRESS;Database=MiniORM;Integrated Security=true";

            SoftUniDbContext context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            Employee employee = context.Employees.Last();

            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
