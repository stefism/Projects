using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }
        //•	PrisonerId – integer, Primary Key

        public virtual Prisoner Prisoner { get; set; }
        //•	Prisoner – the officer’s prisoner(required)

        public int OfficerId { get; set; }
        //•	OfficerId – integer, Primary Key

        public virtual Officer Officer { get; set; }
        //•	Officer – the prisoner’s officer(required)
    }
}
