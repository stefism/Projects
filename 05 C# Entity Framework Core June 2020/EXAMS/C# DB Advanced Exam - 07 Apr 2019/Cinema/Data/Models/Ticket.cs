using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        public decimal Price { get; set; }
        //•	Price – decimal (non-negative, minimum value: 0.01) (required)

        public int CustomerId { get; set; }
        //•	CustomerId – integer, foreign key(required)

        public virtual Customer Customer { get; set; }
        //•	Customer – the customer’s ticket 

        public int ProjectionId { get; set; }
        //•	ProjectionId – integer, foreign key(required)

        public virtual Projection Projection { get; set; }
        //•	Projection – the projection’s ticket
    }
}
