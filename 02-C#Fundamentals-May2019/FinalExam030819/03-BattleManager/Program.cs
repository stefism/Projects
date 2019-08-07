using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var playersDictionary = new Dictionary<string, Player>();

            while (true)
            {
                string[] currentInfo = Console.ReadLine().Split(":");

                string command = currentInfo[0];

                if (command == "Results")
                {
                    break;
                }

                else if (command == "Add")
                {
                    string player = currentInfo[1];

                    int health = int.Parse(currentInfo[2]);
                    int energy = int.Parse(currentInfo[3]);

                    if (!playersDictionary.ContainsKey(player))
                    {
                        playersDictionary[player] = new Player { PlayerEnergy = energy};
                    }

                    playersDictionary[player].PlayerHealth += health;
                }

                else if (command == "Attack")
                {
                    string attackerName = currentInfo[1];
                    string defenderName = currentInfo[2];
                    int damage = int.Parse(currentInfo[3]);

                    if (playersDictionary.ContainsKey(attackerName) && playersDictionary.ContainsKey(defenderName))
                    {
                        playersDictionary[defenderName].PlayerHealth -= damage;

                        if (playersDictionary[defenderName].PlayerHealth < 1)
                        {
                            playersDictionary.Remove(defenderName);

                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        playersDictionary[attackerName].PlayerEnergy -= 1;

                        if (playersDictionary[attackerName].PlayerEnergy < 1)
                        {
                            playersDictionary.Remove(attackerName);

                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }

                else if (command == "Delete")
                {
                    string username = currentInfo[1];

                    if (username == "All")
                    {
                        playersDictionary = new Dictionary<string, Player>();
                    }
                    else
                    {
                        playersDictionary.Remove(username);
                    }
                }
            }

            Console.WriteLine($"People count: {playersDictionary.Count}");

            if (playersDictionary.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, playersDictionary
               .OrderByDescending(x => x.Value.PlayerHealth).ThenBy(x => x.Key)
               .Select(x => $"{x.Key} - {x.Value.PlayerHealth} - {x.Value.PlayerEnergy}")));
            }
        }
    }

    class Player
    {
        public int PlayerHealth { get; set; }
        public int PlayerEnergy { get; set; }
    }
}
