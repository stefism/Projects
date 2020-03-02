using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Models.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
