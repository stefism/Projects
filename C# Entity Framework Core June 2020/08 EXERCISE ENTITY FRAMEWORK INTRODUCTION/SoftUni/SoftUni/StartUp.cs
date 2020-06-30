using System;

namespace SoftUni
{
    using SoftUni.Data;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            //string output = GetEmployeesFullInformation(db);
            //string output = GetEmployeesWithSalaryOver50000(db);
            string output = GetEmployeesFromResearchAndDevelopment(db);

            Console.WriteLine(output);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        // 05.	Employees from Research and Development
        {
            var sb = new StringBuilder();



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
