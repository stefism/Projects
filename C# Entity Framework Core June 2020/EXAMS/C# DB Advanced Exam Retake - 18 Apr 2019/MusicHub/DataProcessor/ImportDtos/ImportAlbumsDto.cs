using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumsDto
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        //•	Name – text with min length 3 and max length 40 (required)

        [Required]
        public string ReleaseDate { get; set; }
        //•	ReleaseDate – Date (required)
    }
}
