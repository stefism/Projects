using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Loggers
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string message);
    }
}
