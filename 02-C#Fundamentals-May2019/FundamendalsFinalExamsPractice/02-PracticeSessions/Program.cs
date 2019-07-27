using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Final Exam - 14 April 2019 Group II

            var roadsAndRacers = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split("->");

                string command = input[0];

                if (command == "END")
                {
                    roadsAndRacers = roadsAndRacers.OrderByDescending(x => x.Value.Count)
                        .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine("Practice sessions:");

                    foreach (var item in roadsAndRacers)
                    {
                        Console.WriteLine(item.Key);

                        if (item.Value.Count > 0)
                        {
                            Console.WriteLine("++" + string.Join(Environment.NewLine + "++", item.Value));
                        }
                    }

                    break;
                }

                else if (command == "Add")
                {
                    string road = input[1];
                    string racer = input[2];

                    if (!roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers[road] = new List<string>();
                    }

                    roadsAndRacers[road].Add(racer); // Евентуално ако гърми да провериме дали не подават 2 пъти един и същи racer.
                }

                else if (command == "Move")
                {
                    string currentRoad = input[1];
                    string racer = input[2];
                    string nextRoad = input[3];

                    if (roadsAndRacers[currentRoad].Contains(racer))
                    {
                        roadsAndRacers[currentRoad].Remove(racer);
                        roadsAndRacers[nextRoad].Add(racer);
                    }
                }

                else if (command == "Close")
                {
                    string road = input[1];

                    roadsAndRacers.Remove(road);
                }
            }
        }
    }
}
