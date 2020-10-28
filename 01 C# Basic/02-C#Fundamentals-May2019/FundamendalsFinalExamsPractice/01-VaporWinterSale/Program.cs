using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Retake Final Exam - 20 December 2018

            var gamesDictionary = new Dictionary<string, Games>();

            string[] input = Console.ReadLine().Split(", ");

            foreach (var item in input)
            {
                if (item.Contains("-"))
                {
                    string[] splitedItem = item.Split("-");

                    string gameName = splitedItem[0];
                    double gamePrice = double.Parse(splitedItem[1]);

                    gamesDictionary[gameName] = new Games { GamePrice = gamePrice};
                }

                else if (item.Contains(":"))
                {
                    string[] splitedItem = item.Split(":");
                    string gameName = splitedItem[0];
                    string gameDlc = splitedItem[1];

                    foreach (var game in gamesDictionary)
                    {
                        if (game.Key == gameName)
                        {
                            gamesDictionary[gameName].GameDlc = gameDlc;
                            gamesDictionary[gameName].GamePrice *= 1.2;
                        }
                    }
                }
            }

            foreach (var game in gamesDictionary)
            {
                if (gamesDictionary[game.Key].GameDlc != "NonE")
                {
                    gamesDictionary[game.Key].GamePrice *= 0.5;
                }

                else
                {
                    gamesDictionary[game.Key].GamePrice *= 0.8;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, gamesDictionary
                .Where(x => x.Value.GameDlc != "NonE")
                .OrderBy(x => x.Value.GamePrice)
                .Select(x => $"{x.Key} - {x.Value.GameDlc} - {x.Value.GamePrice:F2}")));

            Console.WriteLine(string.Join(Environment.NewLine, gamesDictionary
                .Where(x => x.Value.GameDlc == "NonE")
                .OrderByDescending(x => x.Value.GamePrice)
                .Select(x => $"{x.Key} - {x.Value.GamePrice:F2}")));
        }
    }

    class Games
    {
        //public string GameName { get; set; }
        public string GameDlc { get; set; }
        public double GamePrice { get; set; }

        public Games()
        {
            GameDlc = "NonE";
        }
    }
}
