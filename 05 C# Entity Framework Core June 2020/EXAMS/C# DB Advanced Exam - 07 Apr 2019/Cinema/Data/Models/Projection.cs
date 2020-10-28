using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Models
{
    public class Projection
    {
        public Projection()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        public int MovieId { get; set; }
        //•	MovieId – integer, foreign key(required)

        public virtual Movie Movie { get; set; }
        //•	Movie – the projection’s movie

        public int HallId { get; set; }
        //•	HallId – integer, foreign key(required)

        public virtual Hall Hall { get; set; }
        //•	Hall – the projection’s hall

        public DateTime DateTime { get; set; }
        //•	DateTime - DateTime(required)

        public virtual ICollection<Ticket> Tickets { get; set; }
        //•	Tickets - collection of type Ticket
    }
}
