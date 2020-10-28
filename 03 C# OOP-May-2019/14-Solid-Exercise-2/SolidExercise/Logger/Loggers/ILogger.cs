using LoggerProgram.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Error(string dateTime, string message);
        void Info(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Warning(string dateTime, string message);
    }
}
