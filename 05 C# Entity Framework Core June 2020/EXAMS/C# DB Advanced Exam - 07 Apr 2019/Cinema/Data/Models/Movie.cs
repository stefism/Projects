using Cinema.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Projections = new HashSet<Projection>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string Title { get; set; }
        //•	Title – text with length[3, 20] (required)

        public Genre Genre { get; set; }
        //•	Genre – enumeration of type Genre, with possible values(Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)

        public TimeSpan Duration { get; set; }
        //•	Duration – TimeSpan(required)

        public double Rating { get; set; }
        //•	Rating – double in the range[1, 10] (required)

        [Required, MaxLength(20)]
        public string Director { get; set; }
        //•	Director – text with length[3, 20] (required)

        public virtual ICollection<Projection> Projections { get; set; }
        //•	Projections - collection of type Projection

    }
}
