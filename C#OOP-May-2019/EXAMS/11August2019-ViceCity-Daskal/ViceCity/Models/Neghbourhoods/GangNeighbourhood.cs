using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currentGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivilPlayer in civilPlayers)
                {
                    while (currentCivilPlayer.IsAlive && currentGun.CanFire)
                    {
                        currentCivilPlayer.TakeLifePoints(currentGun.Fire());
                    }

                    if (!currentGun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currentCivilPlayer in civilPlayers)
            {
                if (!currentCivilPlayer.IsAlive)
                {
                    continue;
                }

                foreach (var currentGun in currentCivilPlayer.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && currentGun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(currentGun.Fire());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
