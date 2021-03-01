using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar.App.Data
{
    public class Date
    {
        public Date()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public DateTime? ReservedDate { get; set; }

        public decimal? Price { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public bool IsReserved { get; set; }

        public bool IsNonWorkDay { get; set; }
    }
}
