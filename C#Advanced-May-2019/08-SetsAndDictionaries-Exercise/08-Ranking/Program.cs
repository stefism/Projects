using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_Ranking
{
    class Program
    {
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

            var contestDictionary = new Dictionary<string, Dictionary<string, int>>();

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
                        contestDictionary[userName] = new Dictionary<string, int> ();
                    }

                    if (!contestDictionary[userName].ContainsKey(contestName))
                    {
                        contestDictionary[userName][contestName] = points;
                    }
                    else
                    {
                        if (contestDictionary[userName][contestName] < points)
                        {
                            contestDictionary[userName][contestName] = points;
                        }
                    }
                }
            } 

            contestDictionary = contestDictionary.OrderByDescending(x => x.Value.Select(y => y.Value).Sum()).ToDictionary(x => x.Key, x => x.Value);

            var bestCandidate = contestDictionary.First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Select(x => x.Value).Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var item in contestDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var values in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {values.Key} -> {values.Value}");
                }
            }
        }
    }
}
