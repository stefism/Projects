using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Models
{
    public class ClientProduct
    {
        public string ClientID { get; set; }

        public virtual Client Client { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
