using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Vlogeers>();

            while (true)
            {
                string[] currentInfo = Console.ReadLine().Split();

                if (currentInfo[0] == "Statistics")
                {
                    break;
                }
                else if (currentInfo.Length == 4 && currentInfo[3] == "V-Logger")
                {
                    string vloggerName = currentInfo[0];

                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers[vloggerName] = new Vlogeers();
                    }
                }
                else if (currentInfo.Length == 3 && currentInfo[1] == "followed")
                {
                    string follower = currentInfo[0];
                    string followed = currentInfo[2];

                    if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(followed))
                    {
                        if (follower != followed && !vloggers[follower].Following.Contains(followed))
                        {
                            vloggers[follower].Following.Add(followed);
                            vloggers[followed].Followers.Add(follower);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");

            vloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var vlogger in vloggers.Take(1))
            {
                Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                if (vlogger.Value.Followers.Count > 0)
                {
                    Console.WriteLine($"{string.Join(Environment.NewLine, vlogger.Value.Followers.OrderBy(x => x).Select(x => $"*  {x}"))}");
                }
            }

            int counter = 2;

            foreach (var vlogger in vloggers.TakeLast(vloggers.Count - 1)
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{counter++}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }
        }
    }

    class Vlogeers
    {
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public Vlogeers()
        {
            Followers = new List<string>();
            Following = new List<string>();
        }
    }
}
