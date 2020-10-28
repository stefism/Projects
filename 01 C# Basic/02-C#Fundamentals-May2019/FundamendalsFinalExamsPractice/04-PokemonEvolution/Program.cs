using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programming Fundamentals Exam - 09 July 2017 Part 2

            var pokemonsDictionary = new Dictionary<string, List<Pokemon>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                if (input[0] == "wubbalubbadubdub")
                {
                    break;
                }

                string pokemonName = input[0];

                if (input.Length == 1)
                {
                    foreach (var pokemon in pokemonsDictionary)
                    {
                        if (pokemon.Key == pokemonName)
                        {
                            Console.WriteLine($"# {pokemon.Key}");
                            Console.WriteLine(string.Join(Environment.NewLine, pokemon.Value
                                .Select(x => $"{x.Evolution} <-> {x.Index}")));
                        }
                    }
                    continue;
                }

                string pokemonEvolution = input[1];
                int pokemonIndex = int.Parse(input[2]);

                if (!pokemonsDictionary.ContainsKey(pokemonName))
                {
                    pokemonsDictionary[pokemonName] = new List<Pokemon>();
                }

                pokemonsDictionary[pokemonName].Add( new Pokemon
                { Evolution = pokemonEvolution, Index = pokemonIndex});
            }

            foreach (var pokemon in pokemonsDictionary)
            {
                Console.WriteLine($"# {pokemon.Key}");

                Console.WriteLine(string.Join(Environment.NewLine, pokemon.Value
                    .OrderByDescending(x => x.Index).Select(x => $"{x.Evolution} <-> {x.Index}")));
            }
        }
    }

    class Pokemon
    {
        public string Evolution { get; set; }
        public int Index { get; set; }
    }
}
