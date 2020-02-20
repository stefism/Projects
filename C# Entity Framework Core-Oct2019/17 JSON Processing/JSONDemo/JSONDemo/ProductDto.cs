using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDemo
{
    public class ProductDto
    {
            public string Name { get; set; }

            public double Price { get; set; }

            public int SellerId { get; set; }

            public int? BuyerId { get; set; }
    }
}
