using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Services.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public ProductType ProductType { get; set; }
    }
}
