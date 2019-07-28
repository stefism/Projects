using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, List<Contest>>();
            var userPoints = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string user = input[0];

                if (user == "no more time")
                {
                    foreach (var usersItems in users.Values)
                    {
                        foreach (var values in usersItems)
                        {
                            if (!userPoints.ContainsKey(values.UserName))
                            {
                                userPoints[values.UserName] = values.UserPoints;
                            }
                            else
                            {
                                userPoints[values.UserName] += values.UserPoints;
                            }
                        }
                    }

                    foreach (var item in users)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                        int counter = 1;

                        //item.Value.OrderByDescending(x => x.UserPoints).ThenBy(x => x.UserName)
                        //    .ToList().ForEach(x => Console.WriteLine($"{counter++}. {x.UserName} <::> {x.UserPoints}"));
                        // Прави същото като долното.

                        Console.WriteLine(string.Join(Environment.NewLine, item.Value
                            .OrderByDescending(x => x.UserPoints).ThenBy(x => x.UserName)
                            .Select(x => $"{counter++}. {x.UserName} <::> {x.UserPoints}")));
                    }

                    int counter2 = 1;

                    Console.WriteLine("Individual standings:");

                    Console.WriteLine(string.Join(Environment.NewLine, userPoints
                        .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                        .Select(x => $"{counter2++}. {x.Key} -> {x.Value}")));

                    break;
                }

                string contest = input[1];
                int points = int.Parse(input[2]);

                if (!users.ContainsKey(contest))
                {
                    users[contest] = new List<Contest>();
                }

                foreach (var item in users)
                {
                    if (!item.Value.Select(x => x.UserName).Contains(user))
                    {
                        users[contest].Add(new Contest { UserName = user, UserPoints = points });
                        break;
                    }
                    else
                    {
                        if (item.Value.Any(x => x.UserName == user && x.UserPoints < points))
                        {

                            Contest @class = item.Value.FirstOrDefault(x => x.UserName == user);

                            if (@class.UserPoints < points)
                            {
                                @class.UserPoints = points;
                                userPoints[user] += points;
                                break;
                            }

                            //foreach (var values in item.Value)
                            //{
                            //    if (values.UserName == user)
                            //    {
                            //        values.UserPoints = points;
                            //        break;
                            //    }
                            //} // - Прави същото като горното.

                            break;
                        }
                    }
                }
            }
        }
    }

    class Contest
    {
        public string UserName { get; set; }
        public int UserPoints { get; set; }

        public Contest()
        {
            UserName = string.Empty;
            UserPoints = 0;
        }
    }
}
