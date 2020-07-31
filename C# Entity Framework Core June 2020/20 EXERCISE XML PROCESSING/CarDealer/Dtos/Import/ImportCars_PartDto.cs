using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    //XmlType("parts")]
    [XmlType("partId")]
    public class ImportCars_PartDto
    {
        //[XmlElement("partId id")]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }

    //<parts>
    //  <partId id = "38" />
    //    ... ect....
}
