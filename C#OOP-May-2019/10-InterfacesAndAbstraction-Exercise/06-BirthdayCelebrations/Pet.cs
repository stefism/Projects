using System;
using System.Collections.Generic;
using System.Text;

namespace _05_BorderControl
{
    public class Pet : Resident
    {
        public Pet(string name, string birthdate) : base (name, birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
