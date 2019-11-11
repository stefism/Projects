using MortalEngines.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines
{
    public class Engine
    {
        public void Run()
        {
            MachinesManager mm = new MachinesManager();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string command = inputArgs[0];

                if (command == "Quit")
                {
                    break;
                }

                string name = inputArgs[1];

                try
                {
                    switch (command)
                    {
                        case "HirePilot":

                            Console.WriteLine(mm.HirePilot(name));
                            break;

                        case "PilotReport":
                            Console.WriteLine(mm.PilotReport(name));
                            break;

                        case "ManufactureTank":
                            double attack = double.Parse(inputArgs[2]);
                            double defence = double.Parse(inputArgs[3]);

                            Console.WriteLine(mm.ManufactureTank(name, attack, defence));
                            break;

                        case "ManufactureFighter":
                            attack = double.Parse(inputArgs[2]);
                            defence = double.Parse(inputArgs[3]);

                            Console.WriteLine(mm.ManufactureFighter(name, attack, defence));
                            break;

                        case "MachineReport":
                            Console.WriteLine(mm.MachineReport(name));
                            break;

                        case "AggressiveMode":
                            Console.WriteLine(mm.ToggleFighterAggressiveMode(name));
                            break;

                        case "DefenseMode":
                            Console.WriteLine(mm.ToggleTankDefenseMode(name));
                            break;

                        case "Engage":
                            string machineName = inputArgs[2];

                            Console.WriteLine(mm.EngageMachine(name, machineName));
                            break;

                        case "Attack":
                            string attackMachine = inputArgs[1];
                            string defendingMachine = inputArgs[2];

                            Console.WriteLine(mm.AttackMachines(attackMachine, defendingMachine));
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
