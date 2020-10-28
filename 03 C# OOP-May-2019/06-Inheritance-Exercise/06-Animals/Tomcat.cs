using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, gender)
        {
            Gender = gender;
        }

        private static string gender = "Male";

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
