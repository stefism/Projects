using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> planetItems = planet.Items.ToList();

            if (planetItems.Count == 0)
            {
                return;
            }

            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    astronaut.Bag.Items.Add(planetItems[0]);
                    planetItems.RemoveAt(0);

                    astronaut.Breath();

                    if (astronaut.Oxygen <= 0)
                    {
                        astronaut.Bag.Items.Clear();
                    }

                    if (planetItems.Count == 0)
                    {
                        return;
                    }
                }
            }
        }
    }
}
