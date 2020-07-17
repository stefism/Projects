using System;
using System.Collections.Generic;

namespace LinqDemo.Models
{
    public partial class Artists
    {
        public Artists()
        {
            ArtistMetadata = new HashSet<ArtistMetadata>();
            SongArtists = new HashSet<SongArtists>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadata> ArtistMetadata { get; set; }
        public virtual ICollection<SongArtists> SongArtists { get; set; }
    }
}
