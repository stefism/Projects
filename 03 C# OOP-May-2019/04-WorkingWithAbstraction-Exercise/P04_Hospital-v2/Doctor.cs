using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in Patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
