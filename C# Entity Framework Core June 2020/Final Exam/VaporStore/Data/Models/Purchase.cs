using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        public virtual PurchaseType Type { get; set; }
        //•	Type – enumeration of type PurchaseType, with possible values(“Retail”, “Digital”) (required)

        [Required]
        public string ProductKey { get; set; }
        //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes(ex. “ABCD-EFGH-1J3L”) (required)

        public DateTime Date { get; set; }
        //•	Date – Date(required)

        public int CardId { get; set; }
        //•	CardId – integer, foreign key(required)

        public virtual Card Card { get; set; }
        //•	Card – the purchase’s card(required)

        public int GameId { get; set; }
        //•	GameId – integer, foreign key(required)

        public virtual Game Game { get; set; }
        //•	Game – the purchase’s game(required)

    }
}
