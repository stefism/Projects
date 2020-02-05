using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolCarSystem.Data
{
    public static class DataValidations
    {
        public static class Make
        {
            public const int MaxName = 20;
        }

        public static class Model
        {
            public const int MaxName = 20;
        }

        public static class Car
        {
            public const int VinLength = 17;
            public const int ColorMaxLength = 15;
        }
    }
}
