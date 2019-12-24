using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Contracts;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;
        public HealthPotion() : base(DefaultWeight)
        {

        }

        public override void AffectCharacter(ICharacter character)
        {
            base.AffectCharacter(character);

            character.Health+= 20;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
