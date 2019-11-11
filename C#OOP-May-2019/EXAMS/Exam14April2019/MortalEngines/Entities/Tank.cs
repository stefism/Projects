using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenceMode = false;
        public Tank(string name, double attackPoints, 
            double defensePoints, double healthPoints = 100) 
            : base(name, attackPoints, defensePoints)
        {
            HealthPoints = 100;
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
