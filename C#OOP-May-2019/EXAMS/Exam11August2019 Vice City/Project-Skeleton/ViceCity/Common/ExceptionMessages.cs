using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerName 
            = "Player's name cannot be null or a whitespace!";

        public const string PlayerLivePointsBelowZero
            = "Player life points cannot be below zero!";

        public const string InvalidGunName = "Name cannot be null or a white space!";

        public const string BulletsCannotBelowZero = "Bullets cannot be below zero!";

        public const string TotalBulletCannotBelowZero
            = "Total bullets cannot be below zero!";

        public const string InvalidGunType = "Invalid gun type!";

        public const string NoGunsInTheQueue = "There are no guns in the queue!";

        public const string CivilPlayerNotExist
            = "Civil player with that name doesn't exists!";
    }
}
