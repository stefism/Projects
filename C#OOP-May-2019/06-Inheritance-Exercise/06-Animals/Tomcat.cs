using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender = "male")
            : base(name, age, gender)
        {
            Gender = "male";
        }
    }
}
