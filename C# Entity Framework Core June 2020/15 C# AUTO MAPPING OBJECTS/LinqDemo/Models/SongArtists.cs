using System;
using System.Collections.Generic;

namespace LinqDemo.Models
{
    public partial class SongArtists
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public int Order { get; set; }

        public virtual Artists Artist { get; set; }
        public virtual Songs Song { get; set; }
    }
}
