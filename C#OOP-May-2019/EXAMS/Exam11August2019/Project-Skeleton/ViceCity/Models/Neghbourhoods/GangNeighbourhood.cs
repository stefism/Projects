using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        private Queue<IGun> mainPlayerGuns;

        private int civilPlayersCount;
        private int livePoints;
        private IGun currGun;
        private IGun mainPlayerCurrentGun;
        private int currGunLivePoints;
        
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            int civilPlayersGunsCount = civilPlayers.Select(p => p.GunRepository.Models.Count).Sum();

            if (mainPlayer.GunRepository.Models.Count == 0 
                && civilPlayersGunsCount == 0)
            {
                return;
            }

            civilPlayersCount = civilPlayers.Count;

            mainPlayerGuns = new Queue<IGun>(mainPlayer.GunRepository.Models);
            
            //mainPlayerCurrentGun = mainPlayerGuns.Dequeue();

            while (mainPlayerGuns.Count != 0 && civilPlayersCount != 0)
            {
                mainPlayerCurrentGun = mainPlayerGuns.Dequeue();
                foreach (var civilPlayer in civilPlayers)
                {
                    while (true)
                    {
                        livePoints = mainPlayerCurrentGun.Fire();
                        civilPlayer.TakeLifePoints(livePoints);

                        if (mainPlayerCurrentGun.CanFire)
                        {
                            mainPlayer.GunRepository.Remove(mainPlayerCurrentGun);

                            if (mainPlayer.GunRepository.Models.Count == 0)
                            {
                                break;
                            }

                            mainPlayerCurrentGun = mainPlayerGuns.Dequeue();
                        }

                        if (civilPlayer.IsAlive)
                        {
                            civilPlayersCount--;
                            break;
                        }
                    }
                }
            }

            if (civilPlayersGunsCount == 0)
            {
                return;
            }

            if (civilPlayers.Any(p => p.IsAlive) == true)
            {
                while (mainPlayer.IsAlive == false)
                {
                    foreach (var civilPlayer in civilPlayers)
                    {
                        currGun = civilPlayer.GunRepository.Models.First();
                        
                        while (civilPlayer.GunRepository.Models.Count != 0)
                        {
                            currGunLivePoints = currGun.Fire();
                            mainPlayer.TakeLifePoints(currGunLivePoints);

                            if (mainPlayer.IsAlive)
                            {
                                return;
                            }

                            if (currGun.CanFire)
                            {
                                civilPlayer.GunRepository.Remove(currGun);
                                currGun = civilPlayer.GunRepository.Models.First();
                            }
                        }
                    }
                }
            }
        }
    }
}
