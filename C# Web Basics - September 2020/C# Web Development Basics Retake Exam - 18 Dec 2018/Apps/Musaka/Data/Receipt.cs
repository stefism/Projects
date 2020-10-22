using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaka.Data
{
    public class Receipt
    {
        public Receipt()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }

        [Key]
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; }

        public virtual User Cashier { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
