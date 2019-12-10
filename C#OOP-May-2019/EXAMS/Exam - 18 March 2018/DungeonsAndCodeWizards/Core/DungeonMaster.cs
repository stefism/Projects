using DungeonsAndCodeWizards.Core.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Factories.Contracts;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster : IDungeonMaster
    {
        private IList<ICharacter> players;
        private IList<IItem> items;
        private ICharacterFactory characterFactory;
        private IItemFactory itemFactory;

        public DungeonMaster()
        {
            players = new List<ICharacter>();
            items = new List<IItem>();
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
        }
        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            IItem item = itemFactory.CreateItem(itemName);

            items.Add(item);

            return $"{itemName} added to pool.";
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string GiveCharacterItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            ICharacter character = characterFactory
                .CreateCharacter(characterType, name, faction);

            players.Add(character);

            return $"{name} joined the party!";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            ICharacter character = players.FirstOrDefault(p => p.Name == characterName);

            CheckIfCharacterExistInPool(characterName, character);

            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            IItem item = items.Last();

            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            ICharacter character = players.FirstOrDefault(p => p.Name == characterName);

            CheckIfCharacterExistInPool(characterName, character);

            IItem item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            
        }

        private static void CheckIfCharacterExistInPool(string characterName, ICharacter character)
        {
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }
    }
}
