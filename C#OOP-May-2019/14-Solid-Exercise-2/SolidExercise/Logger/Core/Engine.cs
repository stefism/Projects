using LoggerProgram.Appenders;
using LoggerProgram.Enums;
using LoggerProgram.Factories;
using LoggerProgram.Layouts;
using LoggerProgram.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Core
{
    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            List<IAppender> appenders = new List<IAppender>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string result = commandInterpreter.Read(inputInfo);
                Console.WriteLine(result);

                string appenderType = inputInfo[0];
                string layoutType = inputInfo[1];

                ReportLevel reportLevel = ReportLevel.None;

                if (inputInfo.Length > 2)
                {
                    reportLevel = Enum.Parse<ReportLevel>(inputInfo[2], true);
                }

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory
                    .CreateAppender(appenderType, layout, reportLevel);

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            while (true)
            {
                string[] inputInfo = Console.ReadLine().Split("|");

                string result = commandInterpreter.Read(inputInfo);
                Console.WriteLine(result);

                if (inputInfo[0] == "END")
                {
                    break;
                }

                
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
