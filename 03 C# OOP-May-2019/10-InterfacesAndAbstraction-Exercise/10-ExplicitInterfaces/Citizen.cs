using System;
using System.Collections.Generic;
using System.Text;

namespace _10_ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        string IPerson.Name { get; }

        int IPerson.Age { get; }

        public string GetName(string mrs)
        {
            return $"Mr/Ms/Mrs "+Name;
        }

        string IPerson.GetName(string name)
        {
            return name;
        }
    }
}
