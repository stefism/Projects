using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            // Не трябва да присвояваме отново, пропертитата, които идват от бейса.
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}";
        }
    }
}
