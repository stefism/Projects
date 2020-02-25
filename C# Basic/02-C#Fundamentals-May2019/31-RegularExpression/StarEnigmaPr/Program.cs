using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04e_StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> attackedPlanet = new List<string>();
            List<string> destroyedPlanet = new List<string>();

            int countAttacked = 0;
            int countDestrroyed = 0;

            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();

                int countKey = 0;

                countKey = CalculateCountKey(encryptedMessage, countKey);

                string decryptedMessage = string.Empty;

                for (int currentChar = 0; currentChar < encryptedMessage.Length; currentChar++)
                {
                    decryptedMessage += (char)(encryptedMessage[currentChar] - countKey);
                }

                // Regex(@"@(?<planet>[A-Za-z]+).*:(?<population>\d+)!(?<attackType>[A D])!->(?<soldier>\d+)") - Моя. 60 от 100.
                //Regex(@"@(?<planet>[A-Za-z]+)(.*):(?<population>\d+)!(.*)(?<attackType>[A D])!(.*)->(?<soldier>\d+)") - 80 от 100.

                //var regex = new Regex(@"@(?<planet>[A-Za-z]+)(.*):(.*)(?<population>\d+)(.*)!(.*)(?<attackType>[A D])!(.*)->(?<soldier>\d+)");

                var planetName = new Regex(@"@([A-Za-z]+)");
                var attackType = new Regex(@"!([A|D])!");
                var population = new Regex(@":(\d+)");
                var soldier = new Regex(@"->(\d+)");

                var planetMatch = planetName.Match(decryptedMessage);
                var attackTypeMatch = attackType.Match(decryptedMessage);
                var soldierMatch = soldier.Match(decryptedMessage);
                var populationMatch = population.Match(decryptedMessage);

                if (planetMatch.Success && attackTypeMatch.Success && soldierMatch.Success && populationMatch.Success)
                {
                    string planet = planetMatch.Groups[1].Value;
                    string attackTypes = attackTypeMatch.Groups[1].Value;

                    if (attackTypes == "A")
                    {
                        attackedPlanet.Add(planet);
                        countAttacked++;
                    }
                    else
                    {
                        destroyedPlanet.Add(planet);
                        countDestrroyed++;
                    }
                }
            }

            attackedPlanet.Sort();
            destroyedPlanet.Sort();

            // Select(x => $"-> {x}"

            Console.WriteLine($"Attacked planets: {countAttacked}");

            if (attackedPlanet.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, attackedPlanet.Select(x => $"-> {x}")));
            }

            Console.WriteLine($"Destroyed planets: {countDestrroyed}");

            if (destroyedPlanet.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, destroyedPlanet.Select(x => $"-> {x}")));
            }
        }

        private static int CalculateCountKey(string encryptedMessage, int countKey)
        {
            for (int currentChar = 0; currentChar < encryptedMessage.Length; currentChar++)
            {
                string[] containsSymbol = { "s", "t", "a", "r", "S", "T", "A", "R" };

                //if (encryptedMessage[currentChar] == containsSymbol.Where(x => "x"))
                //{
                //    countKey++;
                //}

                if (encryptedMessage[currentChar] == 's' || encryptedMessage[currentChar] == 't'
                    || encryptedMessage[currentChar] == 'a' || encryptedMessage[currentChar] == 'r'
                    || encryptedMessage[currentChar] == 'S' || encryptedMessage[currentChar] == 'T'
                    || encryptedMessage[currentChar] == 'A' || encryptedMessage[currentChar] == 'R')
                {
                    countKey++;
                }
            }

            return countKey;
        }
    }
}
