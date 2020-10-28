using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor
{
    public class ImportHallDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        //•	Name – text with length [3, 20] (required)

        public bool? Is4Dx { get; set; }

        public bool? Is3D { get; set; }

        [Range(1, double.MaxValue)]
        public int Seats { get; set; }
    }
}
