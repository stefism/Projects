using System;
using System.Collections.Generic;
using System.Text;

namespace Musaka.ViewModels
{
    public class ProductWithSumViewModel
    {
        public decimal TotalSum { get; set; }

        public ICollection<ProductInTableViewModel> Products { get; set; }
    }
}
