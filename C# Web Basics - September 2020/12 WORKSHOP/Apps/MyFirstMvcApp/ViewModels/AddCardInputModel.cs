using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.ViewModels
{
    public class AddCardInputModel
    {
        public int Attack { get; set; }

        public int Health { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Keyword { get; set; }       
    }
}
