using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_Ranking
{
    class Program
    {
        class Contest
        {
            public string ContestName { get; set; }
            public int ContestPoints { get; set; }
        }
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();

            while (true)
            {
                string[] currentContestAndPassword = Console.ReadLine().Split(":");

                if (currentContestAndPassword[0] == "end of contests")
                {
                    break;
                }

                string contestName = currentContestAndPassword[0];
                string contestPassword = currentContestAndPassword[1];

                contestsAndPasswords[contestName] = contestPassword;
            }

            var contestDictionary = new Dictionary<string, List<Contest>>();

            while (true)
            {
                string[] contestInfo = Console.ReadLine().Split("=>");

                if (contestInfo[0] == "end of submissions")
                {
                    break;
                }

                string contestName = contestInfo[0];
                string contestPassword = contestInfo[1];
                string userName = contestInfo[2];
                int points = int.Parse(contestInfo[3]);

                if (contestsAndPasswords.ContainsKey(contestName)
                    && contestsAndPasswords[contestName] == contestPassword)
                {
                    if (!contestDictionary.ContainsKey(userName))
                    {
                        contestDictionary[userName] = new List<Contest>();
                    }

                    if (!contestDictionary[userName].Select(x => x.ContestName).Contains(contestName))
                    {
                        contestDictionary[userName].Add(new Contest { ContestName = contestName, ContestPoints = points });
                    }

                    foreach (var names in contestDictionary)
                    {
                        if (names.Key == userName)
                        {
                            foreach (var contest in names.Value)
                            {
                                if (contest.ContestName == contestName)
                                {
                                    if (contest.ContestPoints < points)
                                    {
                                        contest.ContestPoints = points;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            contestDictionary = contestDictionary.OrderByDescending(x => x.Value.Select(y => y.ContestPoints).Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            var bestCandidate = contestDictionary.First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Select(x => x.ContestPoints).Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var item in contestDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var values in item.Value.OrderByDescending(x => x.ContestPoints))
                {
                    Console.WriteLine($"#  {values.ContestName} -> {values.ContestPoints}");
                }
            }
        }
    }
}
