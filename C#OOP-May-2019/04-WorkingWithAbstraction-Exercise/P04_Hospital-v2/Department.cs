using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        public Department()
        {
            Rooms = new List<Room>();
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
