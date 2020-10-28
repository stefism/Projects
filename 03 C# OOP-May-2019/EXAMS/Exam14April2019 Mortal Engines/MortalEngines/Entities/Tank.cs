using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenceMode = false;
        public Tank(string name, double attackPoints,  double defensePoints) 
            : base(name, attackPoints, defensePoints, 100)
            // НА БЕЙС КОНСТРУКТОРА СЕ ПОДАВАТ ДЕФОЛТНИТЕ СТОЙНОСТИ, А ГОРЕ НА ТЕКУЩИЯ СЕ МАХАТ! ИНАЧЕ НЕ РАБОТИ!
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode => defenceMode;

        public void ToggleDefenseMode()
        {
            if (defenceMode)
            {
                defenceMode = false;
            }
            else
            {
                defenceMode = true;
            }

            if (defenceMode)
            {
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else
            {
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            if (defenceMode)
            {
                return base.ToString() + Environment.NewLine + " *Defense: ON";
            }

            return base.ToString() + Environment.NewLine + " *Defense: OFF";
        }
    }
}
