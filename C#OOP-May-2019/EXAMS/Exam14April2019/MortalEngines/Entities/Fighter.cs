using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool agressiveMode = false;
        public Fighter(string name, double attackPoints, 
            double defensePoints, double healthPoints = 200) 
            : base(name, attackPoints, defensePoints)
        {
            HealthPoints = 200;
            ToggleAggressiveMode();
        }

        public bool AggressiveMode => agressiveMode;

        public void ToggleAggressiveMode()
        {
            if (agressiveMode)
            {
                agressiveMode = false;
            }
            else
            {
                agressiveMode = true;
            }

            if (agressiveMode)
            {
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            if (agressiveMode)
            {
                return base.ToString() + Environment.NewLine +  " *Aggressive: ON";
            }

            return base.ToString() + Environment.NewLine + " *Aggressive: OFF";
        }
    }
}
