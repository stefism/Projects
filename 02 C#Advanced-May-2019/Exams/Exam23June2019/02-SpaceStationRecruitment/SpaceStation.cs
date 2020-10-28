using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => data.Count;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Astronaut>();
        }

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astro = data.FirstOrDefault(x => x.Name == name);

            if (astro == null)
            {
                return false;
            }

            data.Remove(astro);

            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            int maxAge = data.Max(x => x.Age);
            Astronaut astro = data.First(x => x.Age == maxAge);

            return astro;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astro = data.FirstOrDefault(x => x.Name == name);

            return astro;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {Name}:");

            foreach (var astro in data)
            {
                sb.AppendLine(astro.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
