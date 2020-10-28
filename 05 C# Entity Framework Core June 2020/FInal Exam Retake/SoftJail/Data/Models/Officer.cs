using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        [Required, MaxLength(30)]
        public string FullName { get; set; }
        //•	FullName – text with min length 3 and max length 30 (required)

        public decimal Salary { get; set; }
        //•	Salary – decimal (non-negative, minimum value: 0) (required)

        public Position Position { get; set; }
        //•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)

        public Weapon Weapon { get; set; }
        //•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)

        public int DepartmentId { get; set; }
        //•	DepartmentId - integer, foreign key(required)

        public virtual Department Department { get; set; }
        //•	Department – the officer's department (required)

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
        //•	OfficerPrisoners - collection of type OfficerPrisoner
    }
}
