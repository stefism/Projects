using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        public Rabbit(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public string Name { get; private set; }
        public string Species { get; private set; }
        public bool Available { get; set; } = true;

        public override string ToString()
        {
            return $"Rabbit ({Species}): {Name}";
        }
    }
}
