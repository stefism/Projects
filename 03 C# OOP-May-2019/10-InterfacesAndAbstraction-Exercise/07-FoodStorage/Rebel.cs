using System;
using System.Collections.Generic;
using System.Text;

namespace _05_BorderControl
{
    public class Rebel : Resident
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Group { get; private set; }
    }
}
