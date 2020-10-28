using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required]
        public string Number { get; set; }
        //•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces(ex. “1234 5678 9012 3456”) (required)

        [Required]
        public string Cvc { get; set; }
        //•	Cvc – text, which consists of 3 digits(ex. “123”) (required)

        public virtual CardType Type { get; set; }
        //•	Type – enumeration of type CardType, with possible values(“Debit”, “Credit”) (required)

        public int UserId { get; set; }
        //•	UserId – integer, foreign key(required)

        public virtual User User { get; set; }
        //•	User – the card’s user(required)

        public virtual ICollection<Purchase> Purchases { get; set; }
        //•	Purchases – collection of type Purchase

    }
}
