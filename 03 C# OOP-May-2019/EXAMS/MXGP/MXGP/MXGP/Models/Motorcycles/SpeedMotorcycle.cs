using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;

        private const int DefaultCubicCentineters = 125;
        private const int MinimumHorsePower = 50;
        private const int MaximumHorsePower = 69;
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, DefaultCubicCentineters)
        {
        }

        public override int HorsePower 
        {
            get => horsePower;

            protected set
            {
                if (value < MinimumHorsePower
                && value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages
                        .InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }
    }
}
