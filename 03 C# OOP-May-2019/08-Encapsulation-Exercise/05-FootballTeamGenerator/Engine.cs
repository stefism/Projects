﻿using System;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        public void Run()
        {
            TeamRepository teamsRepo = new TeamRepository();

            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (inputArgs[0] == "END")
                    {
                        break;
                    }

                    string teamName = inputArgs[1];

                    if (inputArgs[0] == "Team")
                    {
                        teamsRepo.AddTeam(teamName);
                    }

                    else if (inputArgs[0] == "Add")
                    {
                        string playerName = inputArgs[2];

                        int playerEndurance = int.Parse(inputArgs[3]);
                        int playerSprint = int.Parse(inputArgs[4]);
                        int playerDribble = int.Parse(inputArgs[5]);
                        int playerPassing = int.Parse(inputArgs[6]);
                        int playerShooting = int.Parse(inputArgs[7]);

                        Stats stats = new Stats(playerEndurance, playerSprint, playerDribble,
                            playerPassing, playerShooting);

                        Player player = new Player(playerName, stats);

                        teamsRepo.AddPlayerToTheTeam(teamName, player);
                    }

                    else if (inputArgs[0] == "Remove")
                    {
                        string playerName = inputArgs[2];

                        teamsRepo.RemovePlayerFromTheTeam(teamName, playerName);
                    }

                    else if (inputArgs[0] == "Rating")
                    {
                        Team team = teamsRepo.Teams.FirstOrDefault(x => x.Name == teamName);

                        if (team != null)
                        {
                            double teamRating = teamsRepo.CalculateTeamRating(teamName);

                            Console.WriteLine($"{teamName} - {teamRating}");
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
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
