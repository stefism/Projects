using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier(long id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public Soldier(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public decimal Salary { get; protected set; }
    }
}
