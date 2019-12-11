using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100;
        private const int PistolShootBullets = 1;
        public Pistol(string name) 
            : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel > 0)
            {
                BulletsPerBarrel -= PistolShootBullets;
                
                return PistolShootBullets;
            }
            else
            {
                if (TotalBullets >= PistolBulletsPerBarrel)
                {
                    BulletsPerBarrel = PistolBulletsPerBarrel;
                    TotalBullets -= PistolBulletsPerBarrel;

                    BulletsPerBarrel -= PistolShootBullets;

                    return PistolShootBullets;
                }
            }

            return 0;
        }
    }
}
