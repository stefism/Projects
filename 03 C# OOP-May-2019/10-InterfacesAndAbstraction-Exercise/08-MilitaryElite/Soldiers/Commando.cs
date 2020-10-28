using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Commando : Soldier, ICommando
    {
        public Commando(long id, string firstName, string lastName, 
            decimal salary, string corps, List<Mission> missions) 
            : base(id, firstName, lastName, salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;

            this.missions = new List<Mission>();

            this.missions = missions;
        }

        public List<Mission> missions { get; private set; }

        public string Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
