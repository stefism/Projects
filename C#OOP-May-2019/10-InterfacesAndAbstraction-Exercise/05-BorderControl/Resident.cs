using System;
using System.Collections.Generic;
using System.Text;

namespace _05_BorderControl
{
    public class Resident : ICitizen, IRobot
    {
        public Resident(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public Resident(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Model { get; private set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
