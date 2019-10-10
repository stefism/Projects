using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender = "Male")
            : base(name, age, gender)
        {
            Gender = gender;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
