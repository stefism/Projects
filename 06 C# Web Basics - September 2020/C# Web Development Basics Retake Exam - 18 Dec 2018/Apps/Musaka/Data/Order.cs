using Musaka.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaka.Data
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        public virtual User Cashier { get; set; }

        public string ReceiptId { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
