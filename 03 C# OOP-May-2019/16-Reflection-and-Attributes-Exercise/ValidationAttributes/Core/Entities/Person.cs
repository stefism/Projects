using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Core.Attributes;

namespace ValidationAttributes.Core.Entities
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(12, 90)]
        public int Age { get; private set; }
    }
}
