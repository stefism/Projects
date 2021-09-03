using System;
using System.Collections.Generic;

#nullable disable

namespace A1TicketSystem.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            UsersTickets = new HashSet<UsersTicket>();
        }

        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateClosed { get; set; }
        public byte CreateReason { get; set; }
        public byte CloseReason { get; set; }
        public string DepartmentId { get; set; }
        public string UserId { get; set; }

        public virtual Department Department { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UsersTicket> UsersTickets { get; set; }
    }
}
