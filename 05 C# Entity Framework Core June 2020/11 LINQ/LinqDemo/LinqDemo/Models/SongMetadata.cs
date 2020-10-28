using System;
using System.Collections.Generic;

namespace LinqDemo.Models
{
    public partial class SongMetadata
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public short Type { get; set; }
        public string Value { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }

        public virtual Songs Song { get; set; }
        public virtual Sources Source { get; set; }
    }
}
