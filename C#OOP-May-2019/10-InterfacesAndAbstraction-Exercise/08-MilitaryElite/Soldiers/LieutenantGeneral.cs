using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class LieutenantGeneral : Soldier, ILieutenantGeneral
    {
        
        public LieutenantGeneral(long id, string firstName, 
            string lastName, decimal salary, List<Private> currentPrivates) 
            : base(id, firstName, lastName, salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;

            privates = new List<Private>();
            privates.AddRange(currentPrivates);
        }

        public List<Private> privates { get; protected set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine("Privates:");

            foreach (var privat in privates)
            {
                sb.AppendLine(privat.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
