using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel ReportLevel, string message);
    }
}
