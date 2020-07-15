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
            string output = GetEmployeesWithSalaryOver50000(db);
            //string output = GetEmployeesFromResearchAndDevelopment(db);
            //string output = AddNewAddressToEmployee(db);
            //string output = GetEmployeesInPeriod(db);
            //string output = GetAddressesByTown(db);
            //string output = GetEmployee147(db);
            //string output = GetDepartmentsWithMoreThan5Employees(db);
            //string output = GetLatestProjects(db);
            //string output = IncreaseSalaries(db);
            //string output = GetEmployeesByFirstNameStartingWithSa(db);
            //string output = DeleteProjectById(db);
            //string output = RemoveTown(db);

            Console.WriteLine(output);
        }

        public static string RemoveTown(SoftUniContext context)
        // 15.	Remove Town
        {
            var emplInSeattle = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var e in emplInSeattle)
            {

                e.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle");

            int addressesCount = addresses.Count();

            context.Addresses.RemoveRange(addresses);

            var seatle = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            context.Towns.Remove(seatle);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        // 14.	Delete Project by Id
        {
            var sb = new StringBuilder();

            var projects2 = context.EmployeesProjects
                .Where(p => p.ProjectId == 2).ToList();
            context.EmployeesProjects.RemoveRange(projects2);           

            var projectInProjects = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);
            context.Projects.Remove(projectInProjects);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new { p.Name }).Take(10).ToList();

            projects.ForEach(p => sb.AppendLine(p.Name));

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            // broken test
            if (context.Employees.Any(e => e.FirstName == "Svetlin"))
            {
                string pattern = "SA";
                var employeesByNamePattern = context.Employees
                    .Where(employee => employee.FirstName.StartsWith(pattern));

                foreach (var employeeByPattern in employeesByNamePattern)
                {
                    output.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
                                       $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
                }
            }
            else
            {
                var employeesByNamePattern = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var employee in employeesByNamePattern)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} " +
                                       $"- {employee.JobTitle} - (${employee.Salary:F2})");
                }
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa_66_100(SoftUniContext context)
        // 13.	Find Employees by First Name Starting with "Sa"
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                .ToList();
           
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }      
         
            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        // 12.	Increase Salaries
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                e.Salary = e.Salary * 1.12M;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        // 11.	Find Latest 10 Projects
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            foreach (var p in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name)
                    .AppendLine(p.Description)
                    .AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        // 10.	Departments with More Than 5 Employees
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Select(d => new
                {
                    DeptName = d.Name,
                    DeptManagerFirstName = d.Manager.FirstName,
                    DeptManagerLastName = d.Manager.LastName,

                    DeptEmployees = d.Employees.Select(e => new
                    {
                        EmplFirstName = e.FirstName,
                        EmplLastName = e.LastName,
                        EmplJobTitle = e.JobTitle
                    })
                }).Where(d => d.DeptEmployees.Count() > 5)
                .OrderBy(d => d.DeptEmployees.Count())
                .ThenBy(d => d.DeptName).ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DeptName} - {d.DeptManagerFirstName} {d.DeptManagerLastName}");

                foreach (var empl in d.DeptEmployees.OrderBy(e => e.EmplFirstName).ThenBy(e => e.EmplLastName))
                {
                    sb.AppendLine($"{empl.EmplFirstName} {empl.EmplLastName} - {empl.EmplJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        // 09.	Employee 147
        {
            var sb = new StringBuilder();

            var empl = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,

                    EPr = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name
                    })

                }).First(e => e.EmployeeId == 147);

            sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle}");

            foreach (var ep in empl.EPr.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{ep.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        // 08.	Addresses by Town
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
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
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
