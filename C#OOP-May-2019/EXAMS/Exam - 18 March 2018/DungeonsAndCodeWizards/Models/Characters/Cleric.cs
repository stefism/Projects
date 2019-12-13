using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double DefaultBaseHealth = 50;
        private const double DefaultBaseArmor = 25;
        private const double DefaultAbilityPoints = 40;
        private static IBag defaulBag = new Backpack();

        public Cleric(string name, Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, 
                  DefaultAbilityPoints, defaulBag, faction)
        {
        }

        public void Heal(ICharacter character)
        {
            if (!character.IsAlive || !this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += AbilityPoints;
        }
    }
}
