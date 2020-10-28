using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P04_Hospital
{
    public class Room
    {
        public Room()
        {
            Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; set; }

        public bool IsFull => Patients.Count >= 3;

        public void AddPatient(Patient patient)
        {
            if (Patients.Count < 3)
            {
                Patients.Add(patient);
            }
        }

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
