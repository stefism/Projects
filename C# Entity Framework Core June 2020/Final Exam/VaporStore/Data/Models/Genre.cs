using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required]
        public string Name { get; set; }
        //•	Name – text(required)

        public virtual ICollection<Game> Games { get; set; }
        //•	Games - collection of type Game
    }
}
