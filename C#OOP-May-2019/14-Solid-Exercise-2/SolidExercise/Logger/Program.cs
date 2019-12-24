using LoggerProgram.Appenders;
using LoggerProgram.Core;
using LoggerProgram.Enums;
using LoggerProgram.Layouts;
using LoggerProgram.Loggers;
using System;

namespace LoggerProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
