using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string secondName)
        {
            FirstName = firstName;
            LastName = secondName;
            Patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public List<Patient> Patients { get; set; }
    }
}
