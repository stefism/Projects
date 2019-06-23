using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Teamworkrojects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Teams> teams = new List<Teams>();

            while (true)
            {
                // List<string> currentTeamInfo = Console.ReadLine().Split(new string[] {"-", "->"}, StringSplitOptions.None).ToList();

                List<string> currentTeamInfo = Console.ReadLine().Split("-").ToList();

                if (currentTeamInfo[0] == "end of assignment")
                {
                    
                    break;
                }

                string memberName = currentTeamInfo[0];
                string teamName = currentTeamInfo[1];

                Teams currentTeam = new Teams();

                bool isTeamNameExist = IsTeamNameExist(teams);
                bool isTeamCreatorExist = IsTeamCreatorExist(teams, memberName);

                if (isTeamNameExist && !teamName.StartsWith(">"))
                {
                    Console.WriteLine($"Team {currentTeam.TeamName} was alredy created!");
                }

                else if (isTeamCreatorExist && isTeamNameExist && !teamName.StartsWith(">"))
                {
                    Console.WriteLine($"{memberName} cannot create another team!");
                }

                else if (!isTeamNameExist && !teamName.StartsWith(">"))
                {
                    currentTeam.TeamName = teamName;
                    currentTeam.TeamCreator = memberName;
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {currentTeam.TeamName} has been created by {currentTeam.TeamCreator}!");
                }

                else if (teamName.StartsWith(">"))
                {
                    teamName = teamName.Remove(0, 1);
                    bool isTeamMemberExist = IsTeamMemberExist(teams, memberName);

                    if (isTeamNameExist && !isTeamMemberExist)
                    {
                        teams = AddMemberToTeam(teams, teamName, memberName);
                    }

                    else if (isTeamNameExist && !isTeamMemberExist)
                    {
                        Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    }

                    else if (!isTeamNameExist)
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                    }
                }
            }
        }

        static List<Teams> AddMemberToTeam(List<Teams> teams, string teamName, string member)
        {
            foreach (var item in teams)
            {
                if (item.TeamName == teamName)
                {
                    item.TeamMembers.Add(member);
                }
            }

            return teams;
        }
        static bool IsTeamCreatorExist(List<Teams> teams, string member)
        {
            foreach (var item in teams)
            {
                if (item.TeamCreator == member)
                {
                    return true;
                }
            }

            return false;
        }
        static bool IsTeamMemberExist(List<Teams> teams, string member)
        {
            foreach (var item in teams)
            {
                for (int i = 0; i < item.TeamMembers.Count - 1; i++)
                {
                    if (item.TeamMembers[i] == member)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        static bool IsTeamNameExist(List<Teams> teams)
        {
            foreach (var item in teams)
            {
                if (!string.IsNullOrEmpty(item.TeamName))
                {
                    return true;
                }
            }

            return false;
        }
    }
    class Teams
    {
        public string TeamName { get; set; }
        public string TeamCreator { get; set; }
        public List<string> TeamMembers { get; set; }

        public Teams()
        {
            TeamMembers = new List<string>();
        }
        public Teams(string teamName, string teamCreator)
        {
            this.TeamName = teamName;
            this.TeamCreator = teamCreator;
        }
    }
}
