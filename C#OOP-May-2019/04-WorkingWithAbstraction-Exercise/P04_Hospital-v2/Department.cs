using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        public Department()
        {
            Rooms = new List<Room>();
        }

        public Department(string name)
        {
            Name = name;
            Rooms = new List<Room>();
            CreateRooms();
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = Rooms.Where(x => !x.IsFull).FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.AddPatient(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                Rooms.Add(new Room());
            }
        }
    }
}
