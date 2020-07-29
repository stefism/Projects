using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();

            ClientProducts = new HashSet<ClientProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(100)]
        public string Town { get; set; }

        [Required, MaxLength(300)]
        public string Address { get; set; }

        public string Notes { get; set; }

        [NotMapped]
        public decimal TotalPrice => ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity);

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
