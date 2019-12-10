using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Contracts;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int DefaultWeight = 10;
        public ArmorRepairKit() : base(DefaultWeight)
        {

        }

        public override void AffectCharacter(ICharacter character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}
