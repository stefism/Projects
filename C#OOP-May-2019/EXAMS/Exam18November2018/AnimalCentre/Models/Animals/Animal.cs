using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const int MinHappiness = 0;
        private const int MaxHappiness = 100;

        private const int MinEnergy = 0;
        private const int MaxEnergy = 100;

        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;

            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name { get; }
        

        public int Happiness 
        {
            get => happiness;

            set 
            {
                if (value < MinHappiness && value > MaxHappiness)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                happiness = value;
            }
        }

        public int Energy 
        {
            get => energy;

            private set 
            {
                if (value < MinEnergy && value > MaxEnergy)
                {
                    throw new ArgumentException("Invalid energy");
                }

                energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return $"Animal type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
