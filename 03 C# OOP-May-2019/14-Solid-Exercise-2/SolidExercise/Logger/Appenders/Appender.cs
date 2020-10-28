using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get ; set; }

        protected int Counter { get; set; }

        public abstract void Append(string dateTime, ReportLevel ReportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {Counter}, ";
        }
    }
}
