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

                decryptedMessage = DecriptingMessage(encryptedMessage, countKey, decryptedMessage);

                // Regex(@"@(?<planet>[A-Za-z]+).*:(?<population>\d+)!(?<attackType>[A D])!->(?<soldier>\d+)") - Моя. 60 от 100.
                //Regex(@"@(?<planet>[A-Za-z]+)(.*):(?<population>\d+)!(.*)(?<attackType>[A D])!(.*)->(?<soldier>\d+)") 80 от 100.

                var regex = new Regex(@"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*![^@\-!:>]*(?<attackType>[A D])[^@\-!:>]*![^@\-!:>]*->(?<soldier>\d+)");

                var match = regex.Match(decryptedMessage);

                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
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

        private static string DecriptingMessage(string encryptedMessage, int countKey, string decryptedMessage)
        {
            for (int currentChar = 0; currentChar < encryptedMessage.Length; currentChar++)
            {
                decryptedMessage += (char)(encryptedMessage[currentChar] - countKey);
            }

            return decryptedMessage;
        }

        private static int CalculateCountKey(string encryptedMessage, int countKey)
        {
            for (int currentChar = 0; currentChar < encryptedMessage.Length; currentChar++)
            {
                char[] containsSymbol = {'s', 't', 'a', 'r', 'S', 'T', 'A', 'R' };

                if (containsSymbol.Contains(encryptedMessage[currentChar]))
                {
                    countKey++;
                }

                //if (encryptedMessage[currentChar] == 's' || encryptedMessage[currentChar] == 't'
                //    || encryptedMessage[currentChar] == 'a' || encryptedMessage[currentChar] == 'r'
                //    || encryptedMessage[currentChar] == 'S' || encryptedMessage[currentChar] == 'T'
                //    || encryptedMessage[currentChar] == 'A' || encryptedMessage[currentChar] == 'R')
                //{
                //    countKey++;
                //}
            }

            return countKey;
        }
    }
}
