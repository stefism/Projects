using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel > ReportLevel)
            {
                Counter++;
                Console.WriteLine(Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
