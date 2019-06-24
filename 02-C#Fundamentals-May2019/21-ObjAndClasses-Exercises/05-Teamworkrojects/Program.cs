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
                    teams = teams.OrderByDescending(a => a.TeamMembers.Count).ToList();
                    teams = teams.OrderBy(a => a.TeamName).ToList();
                    //teams.ForEach(a => a.TeamMembers.Sort((z, b) => b.CompareTo(z)));
                    teams.ForEach(a => a.TeamMembers.Sort((z, b) => z.CompareTo(b)));
                    List<string> disbandTeam = new List<string>();

                    foreach (var item in teams)
                    {
                        if (item.TeamMembers.Count == 0)
                        {
                            disbandTeam.Add(item.TeamName);
                        }

                        if (item.TeamMembers.Count != 0)
                        {
                            Console.WriteLine(item.TeamName);
                            Console.WriteLine($"- {item.TeamCreator}");

                            for (int i = 0; i < item.TeamMembers.Count; i++)
                            {
                                Console.WriteLine($"-- {item.TeamMembers[i]}");
                            }
                        }
                    }
                    Console.WriteLine("Teams to disband:");
                    Console.WriteLine(string.Join(Environment.NewLine, disbandTeam));
                    break;
                }

                string memberName = currentTeamInfo[0];
                string teamName = currentTeamInfo[1];

                Teams currentTeam = new Teams();

                bool isTeamNameExist = IsTeamNameExist(teams, teamName);
                bool isTeamCreatorExist = IsTeamCreatorExist(teams, memberName);

                if (isTeamNameExist && !teamName.StartsWith(">"))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                else if (isTeamCreatorExist && isTeamNameExist && !teamName.StartsWith(">"))
                {
                    Console.WriteLine($"{memberName} cannot create another team!"); // Тука също да видиме дали работи?
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
                    isTeamNameExist = IsTeamNameExist(teams, teamName);

                    if (isTeamNameExist && !isTeamMemberExist && !isTeamCreatorExist) // isTeamNameExist && !isTeamMemberExist
                    {
                        teams = AddMemberToTeam(teams, teamName, memberName);
                    }

                    else if ((isTeamNameExist && isTeamMemberExist) || (isTeamNameExist && isTeamCreatorExist)) //(isTeamNameExist && !isTeamMemberExist)
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
        static bool IsTeamNameExist(List<Teams> teams, string name)
        {
            if (name.StartsWith(">"))
            {
                string newName = name.Remove(0, 1);
                foreach (var item in teams)
                {
                    if (item.TeamName == newName)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var item in teams)
                {
                    if (item.TeamName == name)
                    {
                        return true;
                    }
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
            TeamName = string.Empty;
            TeamCreator = string.Empty;
        }
        public Teams(string teamName, string teamCreator)
        {
            this.TeamName = teamName;
            this.TeamCreator = teamCreator;
        }
    }
}
