using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;
        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            double resultOxygen = Oxygen - 5.0;

            if (resultOxygen < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen = resultOxygen;
            }
        }
    }
}
