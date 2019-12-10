using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Contracts;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;
        public PoisonPotion() : base(DefaultWeight)
        {

        }

        public override void AffectCharacter(ICharacter character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
        }
    }
}
