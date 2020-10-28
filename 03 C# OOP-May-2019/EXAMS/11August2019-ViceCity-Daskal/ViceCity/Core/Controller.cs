using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using System.Linq;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Neghbourhoods;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            mainPlayer = new MainPlayer();
            civilPlayers = new List<IPlayer>();
            guns = new List<IGun>();
            gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle) == type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            guns.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = guns.FirstOrDefault();

            IPlayer civilPlayer = civilPlayers.FirstOrDefault(p => p.Name == name);

            string message = string.Empty;

            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Civil Player: {name}";
            }
            else
            {
                return "Civil player with that name doesn't exists!";
            }

            guns.Remove(gun);

            return message;
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerLifePoints = mainPlayer.LifePoints;
            int civilPlayerLifePoints = civilPlayers.Select(p => p.LifePoints).Sum();

            gangNeighbourhood.Action(mainPlayer, civilPlayers);

            int mainPlayerLifePointsAfter = mainPlayer.LifePoints;
            int civilPlayerLifePointsAfter = civilPlayers.Select(p => p.LifePoints).Sum();

            if (mainPlayerLifePoints == mainPlayerLifePointsAfter
                && civilPlayerLifePoints == civilPlayerLifePointsAfter)
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();

            int deadCivilPlayers = civilPlayers.Where(p => !p.IsAlive).Count();
            int leftCivilPlayers = civilPlayers.Where(p => p.IsAlive).Count();

            sb.AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {mainPlayerLifePointsAfter}!")
                .AppendLine($"Tommy has killed: {deadCivilPlayers} players!")
                .AppendLine($"Left Civil Players: {leftCivilPlayers}!");

            return sb.ToString().TrimEnd();
        }
    }
}
