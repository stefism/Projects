using System;
using System.Collections.Generic;
using System.Text;

namespace Musaka.ViewModels
{
    public class CreateProductInputModel
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }
    }
}
