using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public double Quantity { get; set; } // Quantity (real number) - Това означава double or decimal! Floating point!

        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = "No description";

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
