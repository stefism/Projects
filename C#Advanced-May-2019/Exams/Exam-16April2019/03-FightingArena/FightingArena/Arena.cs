using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        public Arena(string name)
        {
            Name = name;
        }

        private List<Gladiator> gladiators = new List<Gladiator>();

        //public Arena()
        //{
        //    gladiators = new List<Gladiator>();
        //}

        public int Count => gladiators.Count;

        public string Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiator = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStatPower = gladiators.Max(x => x.GetStatPower());

            return gladiators.FirstOrDefault(x => x.GetStatPower() == maxStatPower);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeaponPower = gladiators.Max(x => x.GetWeaponPower());

            return gladiators.FirstOrDefault(x => x.GetWeaponPower() == maxWeaponPower);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotalPower = gladiators.Max(x => x.GetTotalPower());

            return gladiators.FirstOrDefault(x => x.GetTotalPower() == maxTotalPower);
        }

        public override string ToString()
        {
            return $"[{Name}] - [{Count}] gladiators are participating.";
        }
    }
}
