using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player, IPlayer
    {
        private const int InitialLivePoints = 50;
        public CivilPlayer(string name) 
            : base(name, InitialLivePoints)
        {
        }
    }
}
