using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfInput; i++)
            {
                string[] currentInfo = Console.ReadLine().Split();

                string continent = currentInfo[0];
                string country = currentInfo[1];
                string city = currentInfo[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var currentContinent in continents)
            {
                Console.WriteLine($"{currentContinent.Key}:");

                foreach (var country in currentContinent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
