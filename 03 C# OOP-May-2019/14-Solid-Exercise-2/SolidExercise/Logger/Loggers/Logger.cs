using LoggerProgram.Appenders;
using LoggerProgram.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
        /// <summary>
        /// Please use at least one appender.
        /// </summary>
        /// <param name="appenders"></param>
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders 
        {
            get => appenders;

            private set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Please use at least one appender.");
                }

                appenders = value;
            }
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
