using System;
using System.Collections.Generic;

#nullable disable

namespace A1TicketSystem.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
            UsersTickets = new HashSet<UsersTicket>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<UsersTicket> UsersTickets { get; set; }
    }
}
