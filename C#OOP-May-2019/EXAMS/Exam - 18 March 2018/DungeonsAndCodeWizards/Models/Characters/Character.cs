using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character : ICharacter
    {
        private string name;

        protected Character(string name, double health, double armor, 
            double abilityPoints, IBag bag, Faction faction)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;

            IsAlive = true;
            RestHealMultiplier = 0.2;
        }

        public string Name 
        {
            get => name;

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health { get; set; }

        public double BaseArmor { get; private set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; protected set; }

        public Faction Faction { get; private set; }

        public bool IsAlive
        {
            get 
            {
                return Health != 0;
            }

            private set 
            {

            }
        }

        public double RestHealMultiplier { get; private set; }

        public void GiveCharacterItem(IItem item, ICharacter character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(IItem item)
        {
            CheckIfPlayerAlive();

            Bag.AddItem(item);
        }

        public void Rest()
        {
            CheckIfPlayerAlive();

            double restHealth = BaseHealth * RestHealMultiplier;
            Health += restHealth;
        }

        public void TakeDamage(double hitPoints)
        {
            CheckIfPlayerAlive();

            double armorDamage = Armor - hitPoints;
            double overDamage = 0;

            if (armorDamage > Armor)
            {
                overDamage = armorDamage - Armor;
                Armor = 0;
                Health = -overDamage;
            }
            else
            {
                Armor -= armorDamage;
            }
        }

        public void UseItem(IItem item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(IItem item, ICharacter character)
        {
            item.AffectCharacter(character);
        }

        private void CheckIfPlayerAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
