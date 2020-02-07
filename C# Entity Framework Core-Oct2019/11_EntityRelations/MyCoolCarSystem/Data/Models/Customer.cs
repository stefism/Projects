using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoolCarSystem.Data.Models
{
    using static DataValidations.Customer;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; } // За връзка 1 към 1, тук слагаме само навигационното проперти.

        public ICollection<CarPurchase> Purchases { get; set; }
            = new HashSet<CarPurchase>();
    }
}
