using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int statSum = Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;
            int weaponSum = Weapon.Size + Weapon.Solidity + Weapon.Sharpness;

            return statSum + weaponSum;
        }

        public int GetWeaponPower()
        {
            int weaponSum = Weapon.Size + Weapon.Solidity + Weapon.Sharpness;

            return weaponSum;
        }

        public int GetStatPower()
        {
            int statSum = Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;

            return statSum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int totalPower = GetTotalPower();
            int weaponPower = GetWeaponPower();
            int statPower = GetStatPower();

            sb.AppendLine($"[{Name}] - [{totalPower}");
            sb.AppendLine($"  Weapon Power: {weaponPower}");
            sb.Append($"  Stat Power: {statPower}");

            return sb.ToString();
        }
    }
}
