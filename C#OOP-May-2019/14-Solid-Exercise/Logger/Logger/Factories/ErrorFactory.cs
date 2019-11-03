using Logger.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidOperationException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid date time");
            }

            return new Error(dateTime, message, level);
        }
    }
}
