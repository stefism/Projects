using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Role = IdentityRole.User;
            Cards = new HashSet<UserCard>();
        }
       
        public virtual ICollection<UserCard> Cards { get; set; }
    }
}
