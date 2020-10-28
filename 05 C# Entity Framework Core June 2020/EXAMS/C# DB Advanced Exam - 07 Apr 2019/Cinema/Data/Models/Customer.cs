using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        //•	FirstName – text with length[3, 20] (required)

        [Required, MaxLength(20)]
        public string LastName { get; set; }
        //•	LastName – text with length[3, 20] (required)

        public int Age { get; set; }
        //•	Age – integer in the range[12, 110] (required)

        public decimal Balance { get; set; }
        //•	Balance - decimal (non-negative, minimum value: 0.01) (required)

        public virtual ICollection<Ticket> Tickets { get; set; }
        //•	Tickets - collection of type Ticket
    }
}
