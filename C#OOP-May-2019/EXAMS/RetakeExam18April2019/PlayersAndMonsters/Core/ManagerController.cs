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
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Common;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;

        private IPlayerRepository playerRepository;
        //private ICardRepository playerCardRepository;
        //private ICardRepository totalCardRepository;

        //private List<IPlayer> players;
        //private List<ICard> cards;

        public ManagerController(IPlayerFactory playerFactory, 
            IPlayerRepository playerRepository)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;

            //playerRepository = new PlayerRepository(); // ТАКА НЕ! Инджектване през конструктова! НЮ  (NEW) не трябва да има!
            //totalCardRepository = new CardRepository();

            //players = new List<IPlayer>();
            //cards = new List<ICard>();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);

            //IPlayer player = null;

            //if (type == "Beginner")
            //{
            //    playerCardRepository = new CardRepository();
            //    player = new Beginner(playerCardRepository, username);
            //}
            //else if (type == "Advanced")
            //{
            //    playerCardRepository = new CardRepository();
            //    player = new Advanced(playerCardRepository, username);
            //}

            playerRepository.Add(player);

            //players.Add(player);

            string result = string.Format(ConstantMessages
                .SuccessfullyAddedPlayer, type, username);

            return result;
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

            totalCardRepository.Add(card);
            //cards.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = totalCardRepository.Find(cardName);

            //IPlayer player = players.FirstOrDefault(p => p.Username == username);
            //ICard card = cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playerRepository.Find(attackUser);
            IPlayer attackedPlayer = playerRepository.Find(enemyUser);

            //IPlayer attackPlayer = players.FirstOrDefault(p => p.Username == attackUser);
            //IPlayer attackedPlayer = players.FirstOrDefault(p => p.Username == enemyUser);

            BattleField bf = new BattleField();

            bf.Fight(attackPlayer, attackedPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {attackedPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
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
