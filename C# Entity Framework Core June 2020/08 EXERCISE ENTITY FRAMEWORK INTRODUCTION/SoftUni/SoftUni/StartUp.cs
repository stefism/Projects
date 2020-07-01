using System;

namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            //string output = GetEmployeesFullInformation(db);
            //string output = GetEmployeesWithSalaryOver50000(db);
            //string output = GetEmployeesFromResearchAndDevelopment(db);
            //string output = AddNewAddressToEmployee(db);
            //string output = GetEmployeesInPeriod(db);
            string output = GetAddressesByTown(db);

            Console.WriteLine(output);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        // 8.	Addresses by Town
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    CountEmployees = a.Employees.Count
                })
                .OrderByDescending(a => a.CountEmployees)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10).ToList();

            addresses.ForEach(a => sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.CountEmployees} employees"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        // 07.	Employees and Projects
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFisrstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,                                
                    
                    EPr = e.EmployeesProjects.Select(ep => new 
                    {
                        ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })   

                }).Where(e => e.EPr.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)).Take(10).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFisrstName} {e.ManagerLastName}");
                
                foreach (var ep in e.EPr)
                {                   
                    string endDate = ep.EndDate == null
                        ? "not finished" 
                        : ep.EndDate?.ToString("M/d/yyyy h:mm:ss tt");

                    sb.AppendLine($"--{ep.Name} - {ep.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {endDate}");
                }
            }
        
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        // 06.	Adding a New Address and Updating Employee
        {
            var sb = new StringBuilder();

            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.AddressId,
                    AddressText = e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId).Take(10).ToList();

            employees.ForEach(e => sb.AppendLine($"{e.AddressText}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        // 05.	Employees from Research and Development
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepName = e.Department.Name,
                    e.Salary
                }).Where(e => e.DepName == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .ToList();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepName} - ${e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000
            (SoftUniContext context)
        // 04.	Employees with Salary Over 50 000
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName).ToList();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} - {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation
            (SoftUniContext context)
        // 03.	Employees Full Information
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).OrderBy(e => e.EmployeeId).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }      

            return sb.ToString().TrimEnd();
        }
    }
}
