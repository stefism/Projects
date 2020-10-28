using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    class Plant : Decoration
    {
        private const int DefComfort = 5;
        private const decimal DefPrice = 10;
        public Plant() 
            : base(DefComfort, DefPrice)
        {
        }
    }
}
