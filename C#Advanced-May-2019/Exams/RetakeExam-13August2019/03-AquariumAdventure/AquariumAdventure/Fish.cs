using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }

        public Fish(string name, string color, int fins)
        {
            Name = name;
            Color = color;
            Fins = fins;
        }

        public override string ToString()
        {
            string output = $"Fish: {Name}{Environment.NewLine}Color: {Color}{Environment.NewLine}Number of fins: {Fins}";

            return output;
        }
    }
}
