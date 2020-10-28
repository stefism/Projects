using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(long id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}{Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}
