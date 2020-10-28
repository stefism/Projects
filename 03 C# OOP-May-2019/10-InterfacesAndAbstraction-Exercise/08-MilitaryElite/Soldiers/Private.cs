using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(long id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
