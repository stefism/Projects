using System;
using System.Collections.Generic;

namespace LinqDemo.Models
{
    public partial class Sources
    {
        public Sources()
        {
            ArtistMetadata = new HashSet<ArtistMetadata>();
            SongMetadata = new HashSet<SongMetadata>();
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadata> ArtistMetadata { get; set; }
        public virtual ICollection<SongMetadata> SongMetadata { get; set; }
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
