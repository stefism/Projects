using Cinema.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMoviesDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Title { get; set; }
        //•	Title – text with length [3, 20] (required)

        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }
        //•	Genre – enumeration of type Genre, with possible values (Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)
        
        [Required]
        [DataType(DataType.Duration)] // TODO: Test?
        public string Duration { get; set; }
        //•	Duration – TimeSpan (required)

        [Range(1, 10)]
        public int Rating { get; set; }
        //•	Rating – double in the range [1,10] (required)

        [Required, MinLength(3), MaxLength(20)]
        public string Director { get; set; }
        //•	Director – text with length [3, 20] (required)
    }
}
