using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class Item : IItem
    {
        public int Weight { get; protected set; }

        public Item(int weight)
        {
            Weight = weight;
        }

        public virtual void AffectCharacter(ICharacter character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
