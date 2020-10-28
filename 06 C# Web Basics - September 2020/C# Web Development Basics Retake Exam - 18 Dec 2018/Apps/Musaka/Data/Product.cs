using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaka.Data
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
