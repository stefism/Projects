using Musaka.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaka.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
            Receipts = new HashSet<Receipt>();
            Role = Role.User;
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
