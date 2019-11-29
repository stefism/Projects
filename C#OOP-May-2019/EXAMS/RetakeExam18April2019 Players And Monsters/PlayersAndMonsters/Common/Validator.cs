using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ThrowIfIntegerBelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string @string, string exc_message)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new ArgumentException(exc_message);
            }
        }

        public static void ThrowObjectCannotBeNull(object @object, string exc_message)
        {
            if (@object == null)
            {
                throw new ArgumentException(exc_message);
            }
        }
    }
}
