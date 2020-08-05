using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [XmlElement("FirstName")]
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }
        //•	FirstName– text with min length 3 and max length 20 (required)

        [XmlElement("LastName")]
        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }
        //•	LastName– text with min length 3 and max length 20 (required) 

        [XmlElement("Age")]
        [Range(18, 70)]
        public int Age { get; set; }
        //•	Age – integer (in range between 18 and 70) (required)

        [XmlElement("NetWorth")]
        [Range(0, double.MaxValue)]
        public decimal NetWorth { get; set; }
        //•	NetWorth – decimal (non-negative, minimum value: 0) (required)

        [XmlArray("PerformersSongs")]
        public ImportPerformerSongsDto[] PerformersSongs { get; set; }
    }
}
