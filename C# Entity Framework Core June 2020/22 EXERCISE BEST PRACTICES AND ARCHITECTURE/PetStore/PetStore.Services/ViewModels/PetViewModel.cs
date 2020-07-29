using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Services.ViewModels
{
    public class PetViewModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        public byte Age { get; set; }

        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        public string Breed { get; set; }

        public string ClientId { get; set; }
    }
}
