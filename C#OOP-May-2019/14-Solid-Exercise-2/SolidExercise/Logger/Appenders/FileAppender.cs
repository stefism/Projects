using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using LoggerProgram.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel > ReportLevel)
            {
                Counter++;
                LogFile.Write(string.Format(Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"File size: {LogFile.Size}";
        }
    }
}
