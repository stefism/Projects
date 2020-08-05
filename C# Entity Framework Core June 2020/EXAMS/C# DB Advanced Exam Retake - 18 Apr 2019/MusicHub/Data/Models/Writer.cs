using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string Name { get; set; }
        //•	Name– text with min length 3 and max length 20 (required)

        public string Pseudonym { get; set; }
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters(Example: "Freddie Mercury")

        public virtual ICollection<Song> Songs { get; set; }
        //•	Songs – collection of type Song

    }
}
