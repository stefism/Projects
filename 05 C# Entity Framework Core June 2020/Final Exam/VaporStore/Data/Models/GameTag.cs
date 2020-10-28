using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }
        //•	GameId – integer, Primary Key, foreign key(required)

        public virtual Game Game { get; set; }
        //•	Game – Game

        public int TagId { get; set; }
        //•	TagId – integer, Primary Key, foreign key(required)

        public virtual Tag Tag { get; set; }
        //•	Tag – Tag

    }
}
