namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System.Linq;
    using PlayersAndMonsters.Models.BattleFields;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private List<IPlayer> players;
        private List<ICard> cards;
        public ManagerController()
        {
        }

        public string AddPlayer(string type, string username)
        {
            CardRepository cardRepository = new CardRepository();

            IPlayer player = null;

            if (type == "Beginner")
            {
                player = new Beginner(cardRepository, username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            players.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if (type == "Trap")
            {
                card = new TrapCard(name);
            }

            cards.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = players.FirstOrDefault(p => p.Username == username);
            ICard card = cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = players.FirstOrDefault(p => p.Username == attackUser);
            IPlayer attackedPlayer = players.FirstOrDefault(p => p.Username == enemyUser);

            BattleField bf = new BattleField();

            bf.Fight(attackPlayer, attackedPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {attackedPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
