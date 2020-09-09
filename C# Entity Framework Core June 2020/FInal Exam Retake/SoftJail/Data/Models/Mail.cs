using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required]
        public string Description { get; set; }
        //•	Description– text(required)

        [Required]
        public string Sender { get; set; }
        //•	Sender – text(required)

        [Required]
        public string Address { get; set; }
        //•	Address – text, consisting only of letters, spaces and numbers, which ends with “ str.” (required) (Example: “62 Muir Hill str.“)

        public int PrisonerId { get; set; }
        //•	PrisonerId - integer, foreign key(required)

        public Prisoner Prisoner { get; set; }
        //•	Prisoner – the mail's Prisoner (required)

    }
}
