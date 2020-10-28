using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("")]
    public class CustomerDto
    {
        //[XmlArray("customers")]
        public List<CustomerCustomerDto> Customers { get; set; }
    }
}
