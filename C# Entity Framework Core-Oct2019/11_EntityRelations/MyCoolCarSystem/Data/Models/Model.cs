using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoolCarSystem.Data.Models
{
    using static DataValidations.Model;

    public class Model
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string Modification { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
