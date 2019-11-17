using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Common;
using ViceCity.Core.Contracts;
using ViceCity.Factories.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;
using System.Linq;
using ViceCity.Models.Neghbourhoods;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayerFactory playerFactory;
        private IGunFactory gunFactory;
        private IPlayer mainPlayer;
        private IRepository<IGun> gunRepository;
        private ICollection<IPlayer> players;
        private GangNeighbourhood gangNeighbourhood;
        public Controller(IPlayerFactory playerFactory, 
            IGunFactory gunFactory, 
            IRepository<IGun> gunRepository,
            ICollection<IPlayer> players,
            GangNeighbourhood gangNeighbourhood)
        {
            this.playerFactory = playerFactory;
            this.gunFactory = gunFactory;
            this.gunRepository = gunRepository;
            this.players = players;
            this.gangNeighbourhood = gangNeighbourhood;

            mainPlayer = new MainPlayer();
        }
        public string AddGun(string type, string name)
        {
            Validator.ThrowIfGunTypeIsInvalid
                (type, ExceptionMessages.InvalidGunType);

            gunRepository.Add(gunFactory.CreateGun(type, name));

            return string.Format(SuccessMessages.AddGunIsOK, name, type);
        }

        public string AddGunToPlayer(string name)
        {
            IGun firstGun = gunRepository.Models.FirstOrDefault();

            string firstGunName = firstGun?.Name;

            if (gunRepository.Models.Count == 0)
            {
                return ExceptionMessages.NoGunsInTheQueue;
            }

            if (name == "Vercetti")
            {
                //if (mainPlayer.GunRepository.Models.Contains(firstGun))
                //{
                //    return string.Empty;
                //}

                mainPlayer.GunRepository.Add(firstGun);

                gunRepository.Remove(firstGun);

                return string.Format(SuccessMessages
                    .AddGunToMainPlayerIsOk, firstGunName);
            }

            IPlayer civilPlayer = players
                .FirstOrDefault(x => x.Name == name);

            if (civilPlayer == null)
            {
                return ExceptionMessages.CivilPlayerNotExist;
            }

            civilPlayer.GunRepository.Add(firstGun);
            
            gunRepository.Remove(firstGun);

            return string.Format(SuccessMessages
                .AddGunToCivilPlayerIsOk, firstGunName, civilPlayer.Name);
        }

        public string AddPlayer(string civilPlayerName)
        {
            players.Add(playerFactory.CreatePlayer(civilPlayerName));

            return string.Format(SuccessMessages.AddCivilPlayerIsOk, civilPlayerName);
        }

        public string Fight()
        {
            int totalCivilPlayersInitialHealth = players.Select(p => p.LifePoints).Sum();
            int mainPlayerInitialHealth = mainPlayer.LifePoints;

            gangNeighbourhood.Action(mainPlayer, players);

            int civilPlayersCurrHealth = players.Select(p => p.LifePoints).Sum();
            int mainPlayerCurrHealth = mainPlayer.LifePoints;

            if (totalCivilPlayersInitialHealth == civilPlayersCurrHealth 
                && mainPlayerInitialHealth == mainPlayerCurrHealth)
            {
                return "Everything is okay!";
            }

            var deadCivilPlayers = players.Where(p => p.IsAlive == true);
            int deadCount = deadCivilPlayers.Count();

            var leftCivilPlayers = players.Where(p => p.IsAlive == false);
            int leftCount = leftCivilPlayers.Count();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {deadCount} players!")
                .AppendLine($"Left Civil Players: {leftCount}!");

            return sb.ToString().TrimEnd();
        }
    }
}
