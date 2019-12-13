using DungeonsAndCodeWizards.Core.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Factories.Contracts;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster : IDungeonMaster
    {
        private IList<ICharacter> players;
        private IList<IItem> items;
        private ICharacterFactory characterFactory;
        private IItemFactory itemFactory;

        private int lastSurvivorRoundsCount;

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
            string attackerName = args[0];
            string receiverName = args[1];

            ICharacter attacker = players.FirstOrDefault(p => p.Name == attackerName);
            ICharacter receiver = players.FirstOrDefault(p => p.Name == receiverName);

            CheckIfCharacterExistInPool(attackerName, attacker);
            CheckIfCharacterExistInPool(receiverName, receiver);

            string attackerType = attacker.GetType().Name;

            if (attackerType != "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            
            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);

            return $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
        }

        public string EndTurn()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    double healthBeforeRest = player.Health;
                    player.Rest();
                    double healthAfterRest = player.Health;

                    sb.AppendLine($"{player.Name} rests ({healthBeforeRest} => {healthAfterRest})");
                }
            }

            if (players.Where(x => x.IsAlive).Count() <=1)
            {
                lastSurvivorRoundsCount++;
            }

            if (lastSurvivorRoundsCount == 2)
            {
                sb.AppendLine("Final stats:");
                string status = GetStats();
                sb.AppendLine(status);
                return sb.ToString().TrimEnd();
            }

            return sb.ToString().TrimEnd();
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            ICharacter giver = players.FirstOrDefault(p => p.Name == giverName);
            ICharacter receiver = players.FirstOrDefault(p => p.Name == receiverName);

            CheckIfCharacterExistInPool(giverName, giver);
            CheckIfCharacterExistInPool(receiverName, receiver);

            IItem item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string Heal(string[] args)
        {
            string healerName  = args[0];
            string receiverName = args[1];

            ICharacter healer = players.FirstOrDefault(p => p.Name == healerName );
            ICharacter receiver = players.FirstOrDefault(p => p.Name == receiverName);

            CheckIfCharacterExistInPool(healerName , healer);
            CheckIfCharacterExistInPool(receiverName, receiver);

            string healerType = healer.GetType().Name;

            if (healerType  != "Cleric")
            {
                throw new ArgumentException($"{healerName } cannot heal!");
            }

            Cleric cleric = (Cleric)healer;
            cleric.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRoundsCount == 2)
            {
                return true;
            }

            return false;
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
                throw new InvalidOperationException("Invalid Operation: No items left in pool!");
            }

            IItem item = items.Last();

            character.ReceiveItem(item);

            items.Remove(item);

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
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            ICharacter giver = players.FirstOrDefault(p => p.Name == giverName);
            ICharacter receiver = players.FirstOrDefault(p => p.Name == receiverName);

            CheckIfCharacterExistInPool(giverName, giver);
            CheckIfCharacterExistInPool(receiverName, receiver);

            IItem item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
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
