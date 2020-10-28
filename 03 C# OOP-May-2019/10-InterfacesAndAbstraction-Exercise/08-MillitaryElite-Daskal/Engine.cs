using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class Engine
    {
        public Engine()
        {
            army = new List<ISoldier>();
        }
        private readonly List<ISoldier> army;

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);
                    army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAdd = commandArgs.Skip(5).ToArray();

                    foreach (var @private in privatesToAdd)
                    {
                        ISoldier soldierToAdd = army.First(x => x.Id == @private);

                        general.AddPrivate(soldierToAdd);
                    }

                    army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairArgs = commandArgs.Skip(6).ToArray();

                        AddRepairs(engineer, repairArgs);

                        army.Add(engineer);
                    }
                    catch (InvalidCorpsException)
                    {
                        
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionArgs = commandArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionArgs[i];
                                string state = missionArgs[i + 1];

                                IMission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException)
                            {
                                continue;
                            }
                        }

                        army.Add(commando);
                    }
                    catch (InvalidCorpsException)
                    {

                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepairs(IEngineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hour = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hour);

                engineer.AddRepair(repair);
            }
        }
    }
}
