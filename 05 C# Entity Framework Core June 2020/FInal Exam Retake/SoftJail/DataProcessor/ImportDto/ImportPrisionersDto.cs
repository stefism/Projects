using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisionersDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The [A-Z][a-z]+")]
        public string Nickname { get; set; }

        [Range(18, 65)]        
        public int Age { get; set; }

        [DataType(DataType.DateTime)]
        public string IncarcerationDate { get; set; }

        [DataType(DataType.DateTime)]
        public string ReleaseDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ImportMailsDto[] Mails { get; set; }
    }
}
