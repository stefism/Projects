using PlayersAndMonsters.Core;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Engine
    {
        IReader reader;
        IWriter writer;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }
        public Engine(IReader reader, IWriter writer) : base ()
        {
            this.reader = reader;
            this.writer = writer;
        }

        ManagerController manager = new ManagerController();
        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                if (command == "Exit")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string playerType = inputArgs[1];
                            string playerUserName = inputArgs[2];

                            writer.WriteLine(manager.AddPlayer(playerType, playerUserName));
                            break;

                        case "AddCard":
                            string cardType = inputArgs[1];
                            string cardName = inputArgs[2];

                            writer.WriteLine(manager.AddCard(cardType, cardName));
                            break;

                        case "AddPlayerCard":
                            string userName = inputArgs[1];
                            cardName = inputArgs[2];

                            writer.WriteLine(manager.AddPlayerCard(userName, cardName));
                            break;

                        case "Fight":
                            string attackUser = inputArgs[1];
                            string enemyUser = inputArgs[2];

                            writer.WriteLine(manager.Fight(attackUser, enemyUser));
                            break;

                        case "Report":
                            writer.WriteLine(manager.Report());
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
