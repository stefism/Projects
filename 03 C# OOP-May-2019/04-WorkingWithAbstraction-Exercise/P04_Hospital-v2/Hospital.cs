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

        public void AddDepartment(string name)
        {
            if (!Departments.Any(x => x.Name == name))
            {
                Department department = new Department(name);
                Departments.Add(department);
            }
        }

        public void AddPatient(string doctorName, string departmentName, string patientName)
        {
            Doctor doctor = Doctors.FirstOrDefault(x => x.FullName == doctorName);
            Department department = Departments.FirstOrDefault(x => x.Name == departmentName);

            Patient patient = new Patient(patientName);
            doctor.Patients.Add(patient);
            department.AddPatientInRoom(patient);
        }
    }
}
