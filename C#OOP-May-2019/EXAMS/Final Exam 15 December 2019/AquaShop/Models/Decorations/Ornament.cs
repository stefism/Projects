using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DefComfort = 1;
        private const decimal DefPrice = 5;
        public Ornament() 
            : base(DefComfort, DefPrice)
        {
        }
    }
}
