using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    public class Astronaut
    {
        public Astronaut(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        public override string ToString()
        {
            return $"Astronaut: {Name}, {Age} ({Country})";
        }
    }
}
