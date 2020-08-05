using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        //•	FirstName– text with min length 3 and max length 20 (required)

        [Required, MaxLength(20)]
        public string LastName { get; set; }
        //•	LastName– text with min length 3 and max length 20 (required)
       
        public int Age { get; set; }
        //•	Age – integer(in range between 18 and 70) (required)
        
        public decimal NetWorth { get; set; }
        //•	NetWorth – decimal (non-negative, minimum value: 0) (required)

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
        //•	PerformerSongs - collection of type SongPerformer

    }
}
