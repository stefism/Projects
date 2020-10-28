using System;
using System.Collections.Generic;
using System.Linq;

namespace _01m_CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            List<Employees> employees = new List<Employees>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                List<string> employee = Console.ReadLine().Split().ToList();
                Employees currentEmployeer = new Employees(employee[0], double.Parse(employee[1]), employee[2]);
                employees.Add(currentEmployeer);
            }

            CalculateAndPrintMaxAverageSallary(numberOfEmployees, employees);
        }

        static void CalculateAndPrintMaxAverageSallary(int numberOfemployes, List<Employees> employers)
        {
            List<string> departments = new List<string>();
            foreach (var item in employers)
            {
                departments.Add(item.Department);
            }

            departments = departments.Distinct().ToList();
            double maxSallary = double.MinValue;
            
            string maxSallaryDepartment = string.Empty;

            for (int i = 0; i < departments.Count; i++)
            {
                double currentSallary = 0;

                foreach (var item in employers)
                {
                    if (item.Department == departments[i])
                    {
                        currentSallary += item.Salary;
                    }
                }

                if (currentSallary > maxSallary)
                {
                    maxSallary = currentSallary;
                    maxSallaryDepartment = departments[i];
                }
            }

            Console.WriteLine($"Highest Average Salary: {maxSallaryDepartment}");
            // Да изчисля все пак и средната заплата?

            employers = employers.OrderByDescending(a => a.Salary).ToList();

            foreach (var item in employers)
            {
                if (item.Department == maxSallaryDepartment)
                {
                    Console.WriteLine($"{item.Name} {item.Salary:F2}");
                }
            }
        }
    }
    
    class Employees
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employees(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public Employees()
        {
                
        }
    }
}
