using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;

            Bag = new Backpack(); // !!! ТУКА ДА ВИДИМЕ ТОВА !!!
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        ("Name", ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen != 0.0;
        

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            double resultOxygen = Oxygen - 10.0;

            if (resultOxygen < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen = resultOxygen;
            }
        }
        //The method decreases the astronauts' oxygen by 10 units.
        //• Astronaut's oxygen should not drop below zero

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string result = Bag.Items.Count == 0 
                ? "None" : string.Join(", ", Bag.Items);

            sb.AppendLine($"Name: {Name}")
                .AppendLine($"Oxygen: {Oxygen}")
                .AppendLine($"Bag items: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}
