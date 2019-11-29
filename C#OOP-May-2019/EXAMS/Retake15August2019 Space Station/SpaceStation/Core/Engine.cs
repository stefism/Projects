using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();

            controller = new Controller();
        }
        public void Run()
        {
            string result = string.Empty;

            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string astronautType = input[1];
                        string astronautName = input[2];

                        result = controller.AddAstronaut(astronautType, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input?.Skip(2).ToArray();

                        if (items.Length != 0)
                        {
                            result = controller.AddPlanet(planetName, items);
                        }
                        else
                        {
                            result = controller.AddPlanet(planetName);
                        }
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astronautName = input[1];

                        result = controller.RetireAstronaut(astronautName);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        result = controller.ExplorePlanet(planetName);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

                
            }
        }
    }
}
