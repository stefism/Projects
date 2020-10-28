using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class TeamRepository
    {
        private List<Team> teams;

        public TeamRepository()
        {
            teams = new List<Team>();
        }

        public IReadOnlyCollection<Team> Teams 
        {
            get 
            {
                return teams.AsReadOnly();
            }
            
        }

        public void AddTeam(string teamName)
        {
            Team team = new Team(teamName);

            if (!teams.Contains(team))
            {
                teams.Add(team);
            }
        }

        public void AddPlayerToTheTeam(string teamName, Player player)
        {
            Team team = teams
                .FirstOrDefault(x => x.Name == teamName);

            if (team != null)
            {
                team.AddPlayer(player);
            }

            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        public void RemovePlayerFromTheTeam(string teamName, string playerName)
        {
            Team team = teams
                .FirstOrDefault(x => x.Name == teamName);

            if (team != null)
            {
                Player player = team.ReturnPlayer(playerName);

                if (player != null)
                {
                    team.RemovePlayer(player);
                }
                else
                {
                    throw new ArgumentException($"Player {playerName} is not in {team} team.");
                }
            }

            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        public double CalculateTeamRating(string teamName)
        {
            double teamRating = 0;

            foreach (var currentTeam in teams)
            {
                if (currentTeam.Name == teamName)
                {
                    if (currentTeam.TeamCount != 0)
                    {
                        foreach (var currPlayer in currentTeam.Players)
                        {
                            double currentRating = currPlayer.CalculateStat();

                            teamRating += currentRating;
                        }
                    }
                }
            }

            return Math.Round(teamRating, 0);
        }
    }
}
