using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age)
        {

        }

        public override int Age 
        { 
            get => base.Age;

            protected set 
            {
                if (value > 15)
                {
                    throw new ArgumentException("");
                }

                base.Age = value;
            } 
        }
    }
}
