using PetStore.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public byte Age { get; set; }

        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public bool IsDeleted { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
