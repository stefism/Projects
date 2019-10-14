using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class TeamRepository
    {
        private List<Team> teams;

        public void AddTeam(string teamName)
        {
            Team team = new Team(teamName);

            teams.Add(team);
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
            }

            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
