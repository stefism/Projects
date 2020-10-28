using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class CategoryProductDTO
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}