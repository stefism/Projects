namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System.Text;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;

        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;

        private IBattleField battleField;

        private string result;
        //private ICardRepository totalCardRepository;

        //private List<IPlayer> players;
        //private List<ICard> cards;

        public ManagerController(IPlayerFactory playerFactory, 
            IPlayerRepository playerRepository, ICardFactory cardFactory,
            ICardRepository cardRepository, IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;

            //playerRepository = new PlayerRepository(); // ТАКА НЕ! Инджектване през конструктова! НЮ  (NEW) не трябва да има! Инициализират се като NEW в StartUp класа в случая.
            //totalCardRepository = new CardRepository();

            //players = new List<IPlayer>();
            //cards = new List<ICard>();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            result = string.Format(ConstantMessages
                .SuccessfullyAddedPlayer, type, username);

            return result;

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

            //players.Add(player);
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            
            cardRepository.Add(card);

            result = string.Format(ConstantMessages
                .SuccessfullyAddedCard, type, name);

            return result;

            //ICard card = null;

            //if (type == "Magic")
            //{
            //    card = new MagicCard(name);
            //}
            //else if (type == "Trap")
            //{
            //    card = new TrapCard(name);
            //}

            //cards.Add(card);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);

            //IPlayer player = players.FirstOrDefault(p => p.Username == username);
            //ICard card = cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            result = string.Format(ConstantMessages
                .SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playerRepository.Find(attackUser);
            IPlayer attackedPlayer = playerRepository.Find(enemyUser);

            //IPlayer attackPlayer = players.FirstOrDefault(p => p.Username == attackUser);
            //IPlayer attackedPlayer = players.FirstOrDefault(p => p.Username == enemyUser);

            battleField.Fight(attackPlayer, attackedPlayer);

            result = string.Format(ConstantMessages.FightInfo, attackPlayer.Health, attackedPlayer.Health);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
