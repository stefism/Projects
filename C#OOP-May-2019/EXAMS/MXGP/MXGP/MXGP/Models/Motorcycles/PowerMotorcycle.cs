using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        private const int DefaultCubicCentineters = 450;
        private const int MinimumHorsePower = 70;
        private const int MaximumHorsePower = 100;
        public PowerMotorcycle(string model, int horsePower) 
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
