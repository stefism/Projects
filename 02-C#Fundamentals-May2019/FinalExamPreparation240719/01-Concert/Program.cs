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

            while (true)
            {
                string[] input = Console.ReadLine().Split(";");

                string command = input[0];

                if (command == "start of concert")
                {

                    break;
                }

                else if (command == "Play")
                {
                    string bandName = input[1];
                    int bandTime = int.Parse(input[2]);

                    if (!bandsPlayTime.ContainsKey(bandName))
                    {
                        bandsPlayTime[bandName] = 0;
                    }

                    bandsPlayTime[bandName] += bandTime;
                }

                else if (command == "Add")
                {
                    string bandName = input[1];
                    List<string> bandsMembers = input[2].Split(", ").ToList();

                    if (!bandsInfo.ContainsKey(bandName))
                    {
                        bandsInfo[bandName] = new List<string>(bandsMembers);
                    }
                    else
                    {
                        foreach (var member in bandsMembers)
                        {
                            if (!bandsInfo[bandName].Contains(member))
                            {
                                bandsInfo[bandName].Add(member);
                            }
                        }
                    }
                }
            }
        }
    }
}
