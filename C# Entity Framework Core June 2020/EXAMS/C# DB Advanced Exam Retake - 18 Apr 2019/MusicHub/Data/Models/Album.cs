using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(40)]
        public string Name { get; set; }
        //•	Name – text with min length 3 and max length 40 (required)

        public DateTime ReleaseDate { get; set; }
        //•	ReleaseDate – Date (required)

        public decimal Price => this.Songs.Sum(s => s.Price);
        //•	Price – calculated property (the sum of all song prices in the album

        public int? ProducerId { get; set; }
        //•	ProducerId – integer foreign key

        public virtual Producer Producer { get; set; }
        //•	Producer – the album’s producer

        public virtual ICollection<Song> Songs { get; set; }
        //•	Songs – collection of all songs in the album 


    }
}
