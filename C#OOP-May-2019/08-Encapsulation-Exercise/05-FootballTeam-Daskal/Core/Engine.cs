using _05_FootballTeam_Daskal.Exceptions;
using _05_FootballTeam_Daskal.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_FootballTeam_Daskal.Core
{
    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(";");

                    string cmdType = commandTokens[0];
                    string teamName = commandTokens[1];

                    if (cmdType == "Team")
                    {
                        Team team = new Team(teamName);

                        teams.Add(team);
                    }

                    else if (cmdType == "Add")
                    {
                        ValidateTeamName(teamName);

                        string playerName = commandTokens[2];
                        Stat stat = CreateStat(commandTokens);

                        Player player = new Player(playerName, stat);

                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        team.AddPlayer(player);
                    }

                    else if (cmdType == "Remove")
                    {
                        ValidateTeamName(teamName);

                        string playerName = commandTokens[2];

                        Team team = teams.First(t => t.Name == teamName);

                        team.RemovePlayer(playerName);
                    }

                    else if (cmdType == "Rating")
                    {
                        ValidateTeamName(teamName);

                        Team team = teams.First(t => t.Name == teamName);

                        Console.WriteLine(team);
                    }
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        private static Stat CreateStat(string[] commandTokens)
        {
            int playerEndurance = int.Parse(commandTokens[3]);
            int playerSprint = int.Parse(commandTokens[4]);
            int playerDribble = int.Parse(commandTokens[5]);
            int playerPassing = int.Parse(commandTokens[6]);
            int playerShooting = int.Parse(commandTokens[7]);

            Stat stat = new Stat(playerEndurance, playerSprint, playerDribble,
                playerPassing, playerShooting);
            return stat;
        }

        private void ValidateTeamName(string name)
        {
            Team team = teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeamException, name));
            }
        }
    }
}
