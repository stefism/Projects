using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Factories.Contracts;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public ICharacter CreateCharacter(string type, string name, string faction)
        {
            if (faction != Faction.CSharp.ToString() || faction != Faction.Java.ToString())
            {
                throw new ArgumentException($"Parameter Error: Invalid faction \"{faction}\"!");
            }

            ICharacter character = null;

            if (type == "Warrior")
            {
                if (faction == "CSharp")
                {
                    character = new Warrior(name, Faction.CSharp);
                }
                else if (faction == "Java")
                {
                    character = new Warrior(name, Faction.Java);
                }
            }
            else if (type == "Cleric")
            {
                if (faction == "CSharp")
                {
                    character = new Cleric(name, Faction.CSharp);
                }
                else if (faction == "Java")
                {
                    character = new Cleric(name, Faction.Java);
                }
            }

            if (character == null)
            {
                throw new ArgumentException($"Parameter Error: Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}
