using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double DefaultBaseHealth = 100;
        private const double DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name,  Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, 
                  DefaultAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(ICharacter character)
        {
            if (!character.IsAlive || !this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (Faction == character.Faction)
            {
                throw new ArgumentException
                    ($"Friendly fire! Both characters are from {character.Faction} faction!");
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}
