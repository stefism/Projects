using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }
        public int DoctorId { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }

        [MaxLength(100), Required]
        public string Specialty { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
