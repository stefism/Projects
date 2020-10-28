using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDto
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        //•	Name– text with min length 3 and max length 30 (required)

        [RegularExpression("^([A-Z]{1}[a-z]+) ([A-Z]{1}[a-z]+)$")]
        public string Pseudonym { get; set; }
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters (Example: "Bon Jovi")

        [RegularExpression("^[+][3][5][9] \\d{3} \\d{3} \\d{3}$")]
        public string PhoneNumber { get; set; }
        //•	PhoneNumber – text, consisting only of three groups (separated by space) of three digits and starting always with "+359" (Example: "+359 887 234 267")

        public ImportAlbumsDto[] Albums { get; set; }
    }
}
