using System;
using System.Collections.Generic;

#nullable disable

namespace A1TicketSystem.Models
{
    public partial class UsersTicket
    {
        public string UserId { get; set; }
        public string TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
