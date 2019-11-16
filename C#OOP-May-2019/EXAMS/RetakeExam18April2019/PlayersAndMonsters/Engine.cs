using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        //public Engine()
        //{
        //    reader = new Reader();
        //    writer = new Writer();
        //}
        public Engine(IReader reader, IWriter writer, 
            IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
            // Когато му кажеш така в констуктора явно това замества NEW и NEW не е необходимо да се инициализира с new.
        }

        //ManagerController manager = new ManagerController(); НЕ НЮ ТУКА !!!
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
                    string result = string.Empty;

                    switch (command)
                    {
                        case "AddPlayer":
                            string playerType = inputArgs[1];
                            string playerUserName = inputArgs[2];

                            result = managerController.AddPlayer(playerType, playerUserName);
                            
                            //writer.WriteLine(managerController.AddPlayer(playerType, playerUserName));
                            break;

                        case "AddCard":
                            string cardType = inputArgs[1];
                            string cardName = inputArgs[2];

                            result = managerController.AddCard(cardType, cardName);
                            
                            //writer.WriteLine(managerController.AddCard(cardType, cardName));
                            break;

                        case "AddPlayerCard":
                            string userName = inputArgs[1];
                            cardName = inputArgs[2];

                            result = managerController.AddPlayerCard(userName, cardName);

                            //writer.WriteLine(managerController.AddPlayerCard(userName, cardName));
                            break;

                        case "Fight":
                            string attackUser = inputArgs[1];
                            string enemyUser = inputArgs[2];

                            result = managerController.Fight(attackUser, enemyUser);

                            //writer.WriteLine(managerController.Fight(attackUser, enemyUser));
                            break;

                        case "Report":

                            result = managerController.Report();

                            //writer.WriteLine(managerController.Report());
                            break;
                    }

                    writer.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
