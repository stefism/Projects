using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";

        private int messagesAppended;

        public ConsoleAppender(Ilayout layout, Level level)
        {
            Layout = layout;
            Level = level;
        }

        public Ilayout Layout  {get; private set;}

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format, dateTime
                .ToString(dateFormat, CultureInfo.InvariantCulture), level
                .ToString(), message);

            Console.WriteLine(formattedMessage);
            messagesAppended++;
        }
    }
}
