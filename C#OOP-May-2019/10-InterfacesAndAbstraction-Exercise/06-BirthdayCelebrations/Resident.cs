﻿using System.Numerics;

namespace _05_BorderControl
{
    public class Resident : ICitizen, IRobot
    {
        public Resident(string name, string birthdate, int age, BigInteger id) 
            
        {
            Name = name;
            Birthdate = birthdate;
            Age = age;
            Id = id;
        }

        public Resident(string model, BigInteger id)
        {
            Model = model;
            Id = id;
        }

        public Resident(string name, string birthday)
        {
            Name = name;
            Birthdate = birthday;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }

        public int Age { get; private set; }

        public BigInteger Id { get; set; }

        public string Model { get; set; }

        public override string ToString()
        {
            return Birthdate;
        }
    }
}
