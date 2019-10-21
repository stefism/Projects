using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Engine
    {
        //private List<Private> privates;
        private List<Soldier> soldiers;

        public Engine()
        {
            //privates = new List<Private>();
            soldiers = new List<Soldier>();
        }
        public void Run()
        {
            while (true)
            {
                string[] soldiersArgs = Console.ReadLine().Split();

                if (soldiersArgs[0] == "End")
                {
                    break;
                }

                string soldierType = soldiersArgs[0];
                long soldierId = long.Parse(soldiersArgs[1]);
                string soldierFirstName = soldiersArgs[2];
                string soldierLastName = soldiersArgs[3];

                switch (soldierType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(soldiersArgs[4]);

                        //Private @private = new Private(soldierId, 
                            //soldierFirstName, soldierLastName, salary);

                        Soldier currSoldier = new Private(soldierId,
                            soldierFirstName, soldierLastName, salary);

                        soldiers.Add(currSoldier);

                        //privates.Add(@private);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(soldiersArgs[4]);

                        List<long> privatesIds = new List<long>();
                        
                        for (int i = 5; i < soldiersArgs.Length; i++)
                        {
                            long currentId = long.Parse(soldiersArgs[i]);
                            privatesIds.Add(currentId);
                        }

                        List<Private> currentPrivates = new List<Private>();

                        foreach (var currentSoldier in soldiers)
                        {
                            string type = currentSoldier.GetType().Name;

                            if (type == "Private")
                            {
                                Private privat = (Private)currentSoldier;

                                if (privatesIds.Contains(privat.Id))
                                {
                                    currentPrivates.Add(privat);
                                }
                            }
                        }

                        Soldier general = new LieutenantGeneral(soldierId, soldierFirstName, 
                            soldierLastName, salary, currentPrivates);

                        soldiers.Add(general);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(soldiersArgs[4]);
                        string corps = soldiersArgs[5];

                        List<Repair> repairs = new List<Repair>();

                        for (int i = 6; i < soldiersArgs.Length - 1; i += 2)
                        {
                            string repairPart = soldiersArgs[i];
                            int repairHours = int.Parse(soldiersArgs[i+1]);

                            Repair currRepair = new Repair(repairPart, repairHours);

                            repairs.Add(currRepair);
                        }

                        Soldier engineer = new Engineer(soldierId, 
                            soldierFirstName, soldierLastName, salary, corps, repairs);

                        soldiers.Add(engineer);
                        break;

                    case "Commando":
                        salary = decimal.Parse(soldiersArgs[4]);
                        corps = soldiersArgs[5];

                        List<Mission> missions = new List<Mission>();

                        for (int i = 6; i < soldiersArgs.Length - 1; i += 2)
                        {
                            string missionCodeName = soldiersArgs[i];
                            string missionState = soldiersArgs[i + 1];

                            Mission currMission = new Mission(missionCodeName, missionState);

                            missions.Add(currMission);
                        }

                        Soldier commando = new Commando(soldierId,
                            soldierFirstName, soldierLastName, salary, corps, missions);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
