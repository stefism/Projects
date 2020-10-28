using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.Models
{
    public partial class Towns2
    {
        [Key]
        [Column("TownID")]
        public int TownId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
