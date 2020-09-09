using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportOfficers_PrisionersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; } // TODO: Това да се валидира?
    }
}
