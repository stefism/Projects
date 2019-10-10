using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender = "female")
            : base(name, age, gender)
        {
            Gender = "female";
        }
    }
}
