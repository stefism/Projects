﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Repositories = new HashSet<Repository>();
            Commits = new HashSet<Commit>();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
