using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                string result = GetAddressesByTown(db);
                Console.WriteLine(result);
            }
        }

        // Task 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            //var addresses = context.Addresses
            //    .OrderByDescending(a => a.Employees.Count())
            //    .ThenBy(a => a.Town.Name).ThenBy(a => a.AddressText)
            //    .Take(10).ToList();

            var addresses = context.Addresses
                .Select(a => new 
                {
                    AddrText = a.AddressText,
                    TownName = a.Town.Name,
                    EmplCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmplCount)
                .ThenBy(a => a.TownName).ThenBy(a => a.AddrText)
                .Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddrText}, {address.TownName} - {address.EmplCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context.Towns
                .First(t => t.Name == "Seattle");

            //All addresses in Seattle
            var addressesInTown = context.Addresses
                .Where(a => a.Town == seattle);

            //All employees which lives on the addresses from Seattle
            var emoloyeesToRemoveAddress = context.Employees
                .Where(e => addressesInTown.Contains(e.Address));

            foreach (var e in emoloyeesToRemoveAddress)
            {
                e.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesInTown);

            int addressesCount = addressesInTown.Count();

            context.Towns.Remove(seattle);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }

        //Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in result)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                .ToList(); // Не трябвало да се ту листват за да им се увеличи заплатата.
            // Кат не турнеш ToList то си остава IQuerarable и могат да продължат да му се зимат и правят неща. SaveChanges си го записвало в базата.

            StringBuilder sb = new StringBuilder();

            foreach (var empl in result)
            {
                empl.Salary += empl.Salary * 0.12m;

                context.Update(empl); // Май не трябва да има ъпдейт. При сейв чейнджес то си го записва и обновява май?

                sb.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        // Task 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .First(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var result = context.Addresses
                .Select(a => new
                {
                    a.AddressId,
                    a.AddressText
                })
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var adr in result)
            {
                sb.AppendLine(adr.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        // Task 05
        public static string GetEmployeesFromResearchAndDevelopment
            (SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    depName = e.Department.Name,
                    e.Salary
                })
                .Where(e => e.depName == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in result)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} from {empl.depName} - ${empl.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in result)
            {
                sb.AppendLine($"{empl.FirstName} - {empl.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in result)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} {empl.MiddleName} {empl.JobTitle} {empl.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
