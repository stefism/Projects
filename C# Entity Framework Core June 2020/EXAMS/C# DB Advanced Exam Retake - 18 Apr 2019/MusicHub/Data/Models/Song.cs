using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string Name { get; set; }
        //•	Name – text with min length 3 and max length 20 (required)
       
        public TimeSpan Duration { get; set; }
        //•	Duration – TimeSpan(required)

        public DateTime CreatedOn { get; set; }
        //•	CreatedOn – Date(required)

        public Genre Genre { get; set; }
        //•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)

        public int? AlbumId { get; set; }
        //•	AlbumId– integer foreign key

        public virtual Album Album { get; set; }
        //•	Album– the song’s album

        public int WriterId { get; set; }
        //•	WriterId - integer, foreign key(required)

        public virtual Writer Writer { get; set; }
        //•	Writer – the song’s writer

        public decimal Price { get; set; }
        //•	Price – decimal (non-negative, minimum value: 0) (required)

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
        //•	SongPerformers - collection of type SongPerformer

    }
}
