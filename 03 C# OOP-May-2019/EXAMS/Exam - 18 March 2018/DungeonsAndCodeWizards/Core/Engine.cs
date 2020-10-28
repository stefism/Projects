using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dm = new DungeonMaster();
        public void Run()
        {
            string result = string.Empty;

            while (true)
            {
                try
                {
                    string[] commands = Console.ReadLine().Split();

                    string command = commands[0];
                    string[] args = commands.Skip(1).ToArray();

                    switch (command)
                    {
                        case "JoinParty":
                            result = dm.JoinParty(args);
                            break;

                        case "AddItemToPool":
                            result = dm.AddItemToPool(args);
                            break;

                        case "PickUpItem":
                            result = dm.PickUpItem(args);
                            break;

                        case "UseItem":
                            result = dm.UseItem(args);
                            break;

                        case "UseItemOn":
                            result = dm.UseItemOn(args);
                            break;

                        case "GiveCharacterItem":
                            result = dm.GiveCharacterItem(args);
                            break;

                        case "GetStats":
                            result = dm.GetStats();
                            break;

                        case "Attack":
                            result = dm.Attack(args);
                            break;

                        case "Heal":
                            result = dm.Heal(args);
                            break;

                        case "EndTurn":
                            result = dm.EndTurn();

                            if (result.Contains("Final stats:"))
                            {
                                Console.WriteLine(result);
                                return;
                            }

                            break;

                        case "IsGameOver":
                            result = dm.IsGameOver().ToString();
                            break;
                    }

                    Console.WriteLine(result);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
