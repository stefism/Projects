using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression("^(\\d{4}) (\\d{4}) (\\d{4}) (\\d{4})$")]
        public string Number { get; set; }
        //•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) 

        [Required, Range(3 ,3)]
        public string CVC { get; set; }

        [Required, EnumDataType(typeof(Type))]
        public string Type { get; set; }
        //•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
    }
}
