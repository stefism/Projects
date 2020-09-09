using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            Mails = new HashSet<Mail>();

            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(20)]
        public string FullName { get; set; }
        //•	FullName – text with min length 3 and max length 20 (required)

        [Required]
        public string Nickname { get; set; }
        //•	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)

        public int Age { get; set; }
        //•	Age – integer in the range[18, 65] (required)

        public DateTime IncarcerationDate { get; set; }
        //•	IncarcerationDate ¬– Date(required)

        public DateTime? ReleaseDate { get; set; }
        //•	ReleaseDate– Date

        public decimal? Bail { get; set; }
        //•	Bail– decimal (non-negative, minimum value: 0)

        public int? CellId { get; set; }
        //•	CellId - integer, foreign key

        public virtual Cell Cell { get; set; }
        //•	Cell – the prisoner's cell

        public virtual ICollection<Mail> Mails { get; set; }
        //•	Mails - collection of type Mail

        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
        //•	PrisonerOfficers - collection of type OfficerPrisoner
    }
}