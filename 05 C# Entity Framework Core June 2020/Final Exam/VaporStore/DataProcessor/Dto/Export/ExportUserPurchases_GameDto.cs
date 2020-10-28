using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Game")]
    public class ExportUserPurchases_GameDto
    {        
        [XmlAttribute("title")]
        public string Title { get; set; }
        
        [XmlElement("Genre")]
        public string Genre { get; set; }
        
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
