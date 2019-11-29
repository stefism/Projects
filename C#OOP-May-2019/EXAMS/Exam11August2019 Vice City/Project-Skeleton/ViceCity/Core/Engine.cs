using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;
using ViceCity.Factories.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Factories;
using ViceCity.Models.Players;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IPlayerFactory playerFactory;
        private IGunFactory gunFactory;
        private IPlayer mainPlayer;
        private IRepository<IGun> gunRepository;
        private ICollection<IPlayer> players;
        private GangNeighbourhood gangNeighbourhood;

        private Controller controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            playerFactory = new PlayerFactory();
            gunFactory = new GunFactory();
            mainPlayer = new MainPlayer();
            gunRepository = new GunRepository();
            players = new List<IPlayer>();
            gangNeighbourhood = new GangNeighbourhood();

            controller = new Controller(playerFactory, gunFactory, gunRepository,
                players, gangNeighbourhood);
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                string result = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        string playerName = input[1];

                        result = controller.AddPlayer(playerName);
                    }
                    else if (input[0] == "AddGun")
                    {
                        string gunType = input[1];
                        string gunName = input[2];

                        result = controller.AddGun(gunType, gunName);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        string playerName = input[1];

                        result = controller.AddGunToPlayer(playerName);
                    }
                    else if (input[0] == "Fight")
                    {
                        result = controller.Fight();
                    }            
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }

                writer.WriteLine(result);
            }
        }
    }
}
