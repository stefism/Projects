using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Utilities.Messages
{
    public class ExceptionMessages
    {
        public const string InvalidModel = "Model {0} cannot be less than 4 symbols.";

        public const string InvalidHorsePower = "Invalid horse power: {0}.";

        public const string InvalidName = "Name {0} cannot be less than 5 symbols.";

        public const string MotorcycleCannotBeNull = "Motorcycle cannot be null.";

        public const string RiderCannotBeNull = "Rider cannot be null.";

        public const string RiderNotHaveAMotor = "Rider {0} could not participate in race.";

        public const string RiderAlreadyExist = "Rider {0} is already added in {1} race.";

        public const string InvalidLaps = "Laps cannot be less than 1.";

        public const string RiderIsAlreadyCreated = "Rider {0} is already created.";
    }
}
