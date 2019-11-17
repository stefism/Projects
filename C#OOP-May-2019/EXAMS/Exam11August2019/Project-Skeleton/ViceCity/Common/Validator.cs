using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Common
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhitespace(string value, string excMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidPlayerName);
            }
        }

        public static void ThrowsIfIntBelowZero(int points, string excMessage)
        {
            if (points < 0)
            {
                throw new ArgumentException(ExceptionMessages.PlayerLivePointsBelowZero);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string value, string excMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunName);
            }
        }

        public static void ThrowIfGunTypeIsInvalid(string type, string excMessage)
        {
            if (type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
        }
    }
}
