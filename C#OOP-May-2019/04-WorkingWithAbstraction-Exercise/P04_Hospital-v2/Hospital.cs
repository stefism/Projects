using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            Doctors = new List<Doctor>();
            Departments = new List<Department>();
        }

        public List<Doctor> Doctors { get; set; }
        public List<Department> Departments { get; set; }

        public void AddDoctor(string firstName, string LastName)
        {
            if (!Doctors.Any(x => x.FirstName == firstName && x.LastName == LastName))
            {
                Doctor doctor = new Doctor(firstName, LastName);
                Doctors.Add(doctor);
            }
        }

        public void AddPatient(string doctorName, string patientName)
        {
            Doctor doctor = Doctors.FirstOrDefault(x => x.FullName == doctorName);

            Patient patient = new Patient(patientName);

            doctor.Patients.Add(patient);
        }
    }
}
