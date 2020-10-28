using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, gender)
        {
            
        }

        private static string gender = "Female";

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
