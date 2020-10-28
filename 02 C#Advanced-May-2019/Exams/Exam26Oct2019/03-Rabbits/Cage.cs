using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rabbits
{
    public class Cage
    {

        List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            rabbits = new List<Rabbit>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => rabbits.Count;
        //public List<Rabbit> Rabbits { get; private set; }

        public void Add(Rabbit rabbit)
        {
            if (Capacity > 0)
            {
                rabbits.Add(rabbit);
                Capacity--;
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbitToRemove = rabbits.FirstOrDefault(x => x.Name == name);

            if (rabbitToRemove == null)
            {
                return false;
            }

            rabbits.Remove(rabbitToRemove);
            return true;
        }

        public void RemoveSpecies(string species)
        {
            rabbits = rabbits.Where(x => x.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbitToSell = rabbits.FirstOrDefault(x => x.Name == name);
            rabbitToSell.Available = false;

            return rabbitToSell;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] speciesToSell = rabbits.Where(x => x.Species == species).ToArray();

            foreach (var spec in speciesToSell)
            {
                spec.Available = false;
            }

            return speciesToSell;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {Name}:");

            foreach (var rabb in rabbits)
            {
                if (rabb.Available == true)
                {
                    sb.AppendLine(rabb.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
