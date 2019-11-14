using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string PlayersHealthBelowZero =
            "Player's health bonus cannot be less than zero.";

        public const string PlayerUserNameCannotBeNull =
            "Player's username cannot be null or an empty string.";

        public const string DamagePointsCannotBeLessThanZero =
            "Damage points cannot be less than zero.";

        public const string CardNameCaanotBeNullOrEmpty =
            "Card's name cannot be null or an empty string.";

        public const string CardDamagePointsCannotBeLessThanZero =
            "Card's damage points cannot be less than zero.";

        public const string CardHpCannotBeLessThanZero =
            "Card's HP cannot be less than zero.";

        public const string DeadPlayer = "Player is dead!";

        public const string CardCannotBeNull = "Card cannot be null!";

        public const string CardNameExist = "Card {0} already exists!";

        public const string PlayerCannotBeNull = "Player cannot be null";

        public const string PlayerAllreadyExist = "Player {0} already exists!";
    }
}
