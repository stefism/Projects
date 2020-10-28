using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Engineer : Soldier, IEngineer
    {
        public Engineer(long id, string firstName, 
            string lastName, decimal salary, string corps, List<Repair> currRepairs) 
            : base(id, firstName, lastName, salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;

            Repairs = new List<Repair>();

            Repairs = currRepairs;
        }

        public List<Repair> Repairs { get; private set; }

        public string Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
