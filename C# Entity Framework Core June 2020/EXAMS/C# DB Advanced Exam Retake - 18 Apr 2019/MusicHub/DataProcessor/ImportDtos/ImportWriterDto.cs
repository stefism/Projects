using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportWriterDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        //•	Name– text with min length 3 and max length 20 (required)

        [RegularExpression("^([A-Z]{1}[a-z]+) ([A-Z]{1}[a-z]+)$")]
        public string Pseudonym { get; set; }
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters (Example: "Freddie Mercury")
    }
}
