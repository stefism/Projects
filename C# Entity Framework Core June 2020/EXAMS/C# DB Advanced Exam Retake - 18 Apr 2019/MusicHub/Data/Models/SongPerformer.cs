using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }
        //•	SongId – integer, Primary Key

        public virtual Song Song { get; set; }
        //•	Song – the performer’s song(required)

        public int PerformerId { get; set; }
        //•	PerformerId – integer, Primary Key

        public virtual Performer Performer { get; set; }
        //•	Performer – the song’s performer(required)

    }
}
