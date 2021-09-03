using System;
using System.Collections.Generic;

#nullable disable

namespace A1TicketSystem.Models
{
    public partial class Department
    {
        public Department()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
