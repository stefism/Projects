using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
