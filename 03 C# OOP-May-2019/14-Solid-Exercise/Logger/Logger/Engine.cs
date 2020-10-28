using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger) : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorArgs = command.Split("|");

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = errorFactory.GetError(date, level, message);
                    logger.Log(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(logger.ToString());
        }
    }
}
