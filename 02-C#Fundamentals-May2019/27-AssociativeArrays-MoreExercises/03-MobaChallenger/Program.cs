using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_MobaChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var playersDictionary = new Dictionary<string, List<Player>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                if (input[0] == "Season end")
                {
                    break;
                }

                if (input.Length == 3) // Тука е за добавянето
                {
                    string player = input[0];
                    string position = input[1];
                    int skill = int.Parse(input[2]);

                    if (!playersDictionary.ContainsKey(player))
                    {
                        playersDictionary[player] = new List<Player>
                        {
                            new Player { Position = position,  Skill = skill}
                        }; // Когато добавяш направо тука, няма обикновени скоби.
                    }
                    else
                    {
                        foreach (var item in playersDictionary)
                        {
                            if (item.Key == player)
                            {
                                //if (item.Value.Any(x => x.Position == position && x.Skill < skill)) не работи

                                if (item.Value.Any(x => x.Position == position))
                                {
                                    Player playerValue = item.Value.FirstOrDefault(x => x.Position == position);

                                    if (playerValue.Skill < skill)
                                    {
                                        playerValue.Skill = skill;
                                    }
                                }
                                else // Ако няма такъв position, трябва се добави към текущия player
                                {
                                    playersDictionary[player].Add(new Player { Position = position, Skill = skill });
                                }
                            }
                        }
                    }
                }

                else // Тука е за дуела
                {
                    string[] players = input[0].Split();

                    string player1 = players[0];
                    string player2 = players[2];

                    if (playersDictionary.ContainsKey(player1) && playersDictionary.ContainsKey(player2))
                    {
                        bool isSamePosition = IsPlayersExistSamePosition(playersDictionary, player1, player2);

                        if (isSamePosition)
                        {
                            int player1TotalSum = playersDictionary[player1].Select(x => x.Skill).Sum();
                            int player2TotalSum = playersDictionary[player2].Select(x => x.Skill).Sum();

                            if (player1TotalSum > player2TotalSum)
                            {
                                playersDictionary.Remove(player2);
                            }

                            else if (player1TotalSum < player2TotalSum)
                            {
                                playersDictionary.Remove(player1);
                            }
                        }
                    }
                }
            }

            foreach (var player in playersDictionary
                 .OrderByDescending(x => x.Value.Select(s => s.Skill).Sum())
                 .ThenBy(k => k.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Select(x => x.Skill).Sum()} skill");

                Console.WriteLine(string.Join(Environment.NewLine, player.Value
                    .OrderByDescending(x => x.Skill).ThenBy(x => x.Position)
                    .Select(x => $"- {x.Position} <::> {x.Skill}")));
            }
        }

        private static bool IsPlayersExistSamePosition(Dictionary<string, List<Player>> playersDictionary, string player1, string player2)
        {
            List<string> player1Positions = playersDictionary[player1].Select(x => x.Position).ToList();
            List<string> player2Positions = playersDictionary[player2].Select(x => x.Position).ToList();

            int player1Count = player1Positions.Count;
            int player2Count = player2Positions.Count;

            if (player1Count <= player2Count)
            {
                foreach (var item in player1Positions)
                {
                    if (player2Positions.Contains(item))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var item in player2Positions)
                {
                    if (player1Positions.Contains(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Player
    {
        public string Position { get; set; }
        public int Skill { get; set; }
    }
}
