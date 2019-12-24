using LoggerProgram.Appenders;
using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using LoggerProgram.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, 
            ReportLevel reportLevel)
        {
            switch (type.ToLower())
            {
                case "consoleappender":
                    return new ConsoleAppender(layout) { ReportLevel = reportLevel};

                case "fileappender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };

                default:
                    throw new ArgumentException("Invalid Appender Type");
                    
            }
        }
    }
}
