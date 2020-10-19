using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Submissions = new HashSet<Submission>();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
