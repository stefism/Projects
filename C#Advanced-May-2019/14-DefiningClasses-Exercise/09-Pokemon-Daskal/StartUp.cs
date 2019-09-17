using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Pokemon_Daskal
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);


                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.Pokemons.Add(pokemon);
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var trainerPokemon in trainer.Pokemons)
                        {
                            trainerPokemon.Health -= 10;
                        }
                    }
                }

                foreach (var trainer in trainers)
                {
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
