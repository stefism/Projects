using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, List<Vlogeers>>();

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
                        vloggers[vloggerName] = new List<Vlogeers>();
                    }
                }
                else if (currentInfo.Length == 3 && currentInfo[1] == "followed")
                {
                    string follower = currentInfo[0];
                    string followed = currentInfo[2];

                    if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(followed))
                    {
                        vloggers[follower].Add(new Vlogeers { Following = followed });
                        vloggers[followed].Add(new Vlogeers { Followers = follower });
                    }
                }
            }
        }
    }

    class Vlogeers
    {
        public string Followers { get; set; }
        public string Following { get; set; }
    }
}
