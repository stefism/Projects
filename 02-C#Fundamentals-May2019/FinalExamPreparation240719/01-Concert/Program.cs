using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bandsInfo = new Dictionary<string, List<string>>();
            var bandsPlayTime = new Dictionary<string, int>();

            int totalPlayTime = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split("; ");

                string command = input[0];

                if (command == "start of concert")
                {
                    bandsPlayTime = bandsPlayTime.OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine($"Total time: {totalPlayTime}");

                    Console.WriteLine(string.Join(Environment.NewLine, bandsPlayTime
                        .Select(x => $"{x.Key} -> {x.Value}")));

                    break;
                }

                else if (command == "Play")
                {
                    string bandNamePlay = input[1];
                    int bandTime = int.Parse(input[2]);

                    if (!bandsPlayTime.ContainsKey(bandNamePlay))
                    {
                        bandsPlayTime[bandNamePlay] = 0;
                    }

                    bandsPlayTime[bandNamePlay] += bandTime;
                    totalPlayTime += bandTime;
                }

                else if (command == "Add")
                {
                    string bandNameAdd = input[1];
                    List<string> bandsMembers = input[2].Split(", ").ToList();

                    if (!bandsInfo.ContainsKey(bandNameAdd))
                    {
                        bandsInfo[bandNameAdd] = new List<string>(bandsMembers);
                    }
                    else
                    {
                        foreach (var member in bandsMembers)
                        {
                            if (!bandsInfo[bandNameAdd].Contains(member))
                            {
                                bandsInfo[bandNameAdd].Add(member);
                            }
                        }
                    }
                }
            }

            string bandName = Console.ReadLine();

            Console.WriteLine(bandName);

            foreach (var item in bandsInfo)
            {
                if (item.Key == bandName)
                {
                    Console.WriteLine($"=> {string.Join(Environment.NewLine + "=> ",item.Value)}");
                }
            }
            
            //Console.WriteLine(string.Join(Environment.NewLine, bandsInfo
            //    .Select(x => $"=> {x.Value}")));
        }
    }
}
