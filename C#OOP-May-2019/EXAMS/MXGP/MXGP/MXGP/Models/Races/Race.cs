using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;

        private readonly List<IRider> riders;
        // !!! КОГАТО ИМАШ КОЛЕКЦИЯ, НЕ ЗАБРАВЯЙ ДА Я ИНИЦИАЛИЗИРАШ ЗАДЪЛЖИТЕЛНО !!!

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;

            riders = new List<IRider>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidName, value));
                }

                name = value;
            }
        }

        public int Laps 
        {
            get => laps;

            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLaps);
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
            => riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider),
                    ExceptionMessages.RiderCannotBeNull);
            }

            if (!rider.CanParticipate) // !!! Да внимавам за буловете какво значат !!!
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.RiderNotHaveAMotor, rider.Name));
            }

            if (riders.Any(r => r.Name == rider.Name))
            {
                throw new ArgumentNullException(nameof(rider),
                    string.Format(ExceptionMessages
                    .RiderAlreadyExist, rider.Name, Name));
            }

            riders.Add(rider);
        }
    }
}
