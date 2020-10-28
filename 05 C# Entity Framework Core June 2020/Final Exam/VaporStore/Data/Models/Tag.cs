using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            GameTags = new HashSet<GameTag>();
        }

        [Key]
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required]
        public string Name { get; set; }
        //•	Name – text(required)

        public virtual ICollection<GameTag> GameTags { get; set; }
        //•	GameTags - collection of type GameTag
    }
}
