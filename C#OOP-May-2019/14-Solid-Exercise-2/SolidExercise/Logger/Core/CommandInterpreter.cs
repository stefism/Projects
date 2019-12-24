using LoggerProgram.Appenders;
using LoggerProgram.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Core
{
    public class CommandInterpreter
    {
        List<IAppender> appenders = new List<IAppender>();
        ILogger logger = new Logger(appenders.ToArray());
        public string Read(string[] args)
        {
            string loggerMethodType = args[0];
            string date = args[1];
            string message = args[2];

            switch (loggerMethodType)
            {
                case "INFO":
                    logger.Info(date, message);
                    break;

                case "WARNING":
                    logger.Warning(date, message);
                    break;

                case "ERROR":
                    logger.Error(date, message);
                    break;

                case "CRITICAL":
                    logger.Critical(date, message);
                    break;

                case "FATAL":
                    logger.Fatal(date, message);
                    break;
            }
        }
    }
}
