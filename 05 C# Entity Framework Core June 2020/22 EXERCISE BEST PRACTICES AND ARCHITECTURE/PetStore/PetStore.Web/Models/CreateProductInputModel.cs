using PetStore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Web.Models
{
    public class CreateProductInputModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        //public int ProductType { get; set; }
        public ProductType ProductType { get; set; }
    }
}
