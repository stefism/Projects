using System;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            hospital = new Hospital();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                string departament = inputArgs[0];
                string firstName = inputArgs[1];
                string secondName = inputArgs[2];
                string patient = inputArgs[3];

                string fullName = firstName + " " + secondName;

                hospital.AddDoctor(firstName, secondName);
                hospital.AddDepartment(departament);
                hospital.AddPatient(fullName, departament, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    Department department = hospital.Departments
                        .FirstOrDefault(x => x.Name == departmentName);

                    Console.WriteLine(department);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int targetRoom);

                    if (isRoom)
                    {
                        string departmentName = args[0];

                        Room room = hospital.Departments
                        .FirstOrDefault(x => x.Name == departmentName).Rooms[targetRoom - 1];
                        
                        Console.WriteLine(room);
                    }
                    else
                    {
                        string fullname = args[0] + " " + args[1];

                        Doctor doctor = hospital.Doctors.FirstOrDefault(x => x.FullName == fullname);
                        Console.WriteLine(doctor);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
