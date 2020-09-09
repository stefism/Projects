using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public Cell()
        {
            Prisoners = new HashSet<Prisoner>();
        }

        public int Id { get; set; }
        //•	Id – integer, Primary Key

        public int CellNumber { get; set; }
        //•	CellNumber – integer in the range[1, 1000] (required)

        public bool HasWindow { get; set; }
        //•	HasWindow – bool (required)

        public int DepartmentId { get; set; }
        //•	DepartmentId - integer, foreign key(required)

        public virtual Department Department { get; set; }
        //•	Department – the cell's department (required)

        public virtual ICollection<Prisoner> Prisoners { get; set; }
        //•	Prisoners - collection of type Prisoner
    }
}
