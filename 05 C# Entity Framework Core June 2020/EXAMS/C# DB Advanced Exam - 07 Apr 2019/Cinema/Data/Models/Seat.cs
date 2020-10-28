using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        public int HallId { get; set; }
        //•	HallId – integer, foreign key(required)

        public virtual Hall Hall { get; set; }
        //•	Hall – the seat’s hall
    }
}
