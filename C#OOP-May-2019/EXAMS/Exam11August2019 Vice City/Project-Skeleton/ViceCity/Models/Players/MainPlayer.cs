using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        // Тука разлика нема.

        private const int InitialLivePoints = 100;
        private const string MainPlayerName = "Tommy Vercetti";

        public MainPlayer() 
            : base(MainPlayerName, InitialLivePoints)
        {
        }
    }
}
