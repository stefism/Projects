using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Services.ViewModels
{
    public class ListAllProductsViewModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
