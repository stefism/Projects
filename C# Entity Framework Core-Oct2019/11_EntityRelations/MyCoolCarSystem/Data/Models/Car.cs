using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoolCarSystem.Data.Models
{
    using static DataValidations.Car;
    public class Car
    {
        public int Id { get; set; }

        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(VinLength)]
        public string Vin { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; }
    }
}
