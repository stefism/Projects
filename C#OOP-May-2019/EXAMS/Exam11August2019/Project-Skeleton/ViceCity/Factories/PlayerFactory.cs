using ViceCity.Factories.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players;

namespace ViceCity.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayer player;
        public IPlayer CreatePlayer(string name)
        {
            player = new CivilPlayer(name);

            return player;
        }
    }
}
