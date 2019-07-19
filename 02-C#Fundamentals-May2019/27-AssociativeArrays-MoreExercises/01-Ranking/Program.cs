using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();
            var contestInfo = new Dictionary<string, List<Contest>>();

            while (true)
            {
                string[] currentContestAndPass = Console.ReadLine().Split(":");
                string contestName = currentContestAndPass[0];

                if (contestName == "end of contests")
                {
                    break;
                }

                string contestPassword = currentContestAndPass[1];

                contestsAndPasswords[contestName] = contestPassword;
            }

            while (true)
            {
                string[] contestInformation = Console.ReadLine().Split("=>");
                string contestName = contestInformation[0];

                if (contestName == "end of submissions")
                {
                    break;
                }

                string contestPassword = contestInformation[1];
                string userName = contestInformation[2];
                int userPoints = int.Parse(contestInformation[3]);

                bool isContestNameValid = IsContestValid(contestsAndPasswords, contestName);
                

                if (isContestNameValid)
                {
                    bool isPasswordValid = IsPasswordValid(contestsAndPasswords, contestName, contestPassword);

                    if (isPasswordValid)
                    {
                        if (!contestInfo.ContainsKey(contestName))
                        {
                            contestInfo[contestName] = new List<Contest>();
                        }

                        Contest currentInfo = new Contest();

                        currentInfo.StudentUserName = userName;

                        if (userPoints > currentInfo.StudentPoints)
                        {
                            currentInfo.StudentPoints = userPoints;
                        }

                        contestInfo[contestName].Add(currentInfo);
                    }
                }
            }
        }
        static bool IsPasswordValid(Dictionary<string, string> contests, string contestName, string password)
        {
            if (contests[contestName] == password)
            {
                return true;
            }

            return false;
        }
        static bool IsContestValid(Dictionary<string, string> contests, string contestName)
        {
            foreach (var item in contests)
            {
                if (item.Key == contestName)
                {
                    return true;
                }
            }

            return false;
        }
    }
    class Contest
    {
        //public string StudentPassword { get; set; }
        public string StudentUserName { get; set; }
        public int StudentPoints { get; set; }

        //public Contest(string name, int points)
        //{
        //    this.StudentUserName = name;
        //    this.StudentPoints = points;
        //}
    }
}
