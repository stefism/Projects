using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual void ProduceSound()
        {
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
