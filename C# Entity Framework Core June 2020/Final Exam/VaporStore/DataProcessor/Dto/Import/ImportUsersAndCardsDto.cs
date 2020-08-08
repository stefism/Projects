using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersAndCardsDto
    {
        [Required]
        [RegularExpression("^([A-Z][a-z]+) ([A-Z][a-z]+)$")]
        public string FullName { get; set; }

        [Required, Range(3 ,20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public Card[] Cards { get; set; }
    }
}
