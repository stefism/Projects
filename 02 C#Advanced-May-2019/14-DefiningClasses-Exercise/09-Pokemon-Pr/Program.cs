using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainersAndPokemons = new Dictionary<string, List<Pokemon>>();
            var trainersAndBadgets = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] trainerInfo = Console.ReadLine().Split();

                if (trainerInfo[0] == "Tournament")
                {
                    break;
                }

                Pokemon currentPokemon = new Pokemon();

                string trainerName = trainerInfo[0];
                string pokemonName = trainerInfo[1];
                string pokemonElement = trainerInfo[2];
                double pokemonHealth = double.Parse(trainerInfo[3]);

                currentPokemon.Name = pokemonName;
                currentPokemon.Element = pokemonElement;
                currentPokemon.Health = pokemonHealth;

                if (!trainersAndPokemons.ContainsKey(trainerName))
                {
                    trainersAndPokemons[trainerName] = new List<Pokemon>();
                    Trainer trainerProp = new Trainer();
                    trainerProp.Badges = 0;
                    trainerProp.Pokemons = 0;
                    trainersAndBadgets.Add(trainerName, trainerProp);
                }

                trainersAndPokemons[trainerName].Add(currentPokemon);
                trainersAndBadgets[trainerName].Pokemons++;
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                else if (element == "Fire")
                {
                    CalulateTournament(trainersAndPokemons, trainersAndBadgets, element);
                }

                else if (element == "Water")
                {
                    CalulateTournament(trainersAndPokemons, trainersAndBadgets, element);
                }

                else if (element == "Electricity")
                {
                    CalulateTournament(trainersAndPokemons, trainersAndBadgets, element);
                }
            }

            foreach (var trainer in trainersAndBadgets.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons}");
            }
        }

        private static void CalulateTournament(Dictionary<string, 
            List<Pokemon>> trainersAndPokemons, 
            Dictionary<string, Trainer> trainersAndBadgets, string element)
        {
            bool isElementExist = IsElementExist(trainersAndPokemons, element);

            string trainer = trainersAndPokemons
                    .FirstOrDefault(x => x.Value.Any(y => y.Element == element)).Key;

            if (isElementExist)
            {
                trainersAndBadgets[trainer].Badges++;
            }

            else
            {
                RemoveHealthAndPokemons(trainersAndPokemons, trainer, trainersAndBadgets);
            }
        }

        private static void RemoveHealthAndPokemons(Dictionary<string, 
            List<Pokemon>> trainersAndPokemons, 
            string trainer, Dictionary<string, Trainer> trainersAndBadgets)
        {
            foreach (var currentTrainer in trainersAndPokemons)
            {
                if (currentTrainer.Key == trainer)
                {
                    foreach (var pokemon in currentTrainer.Value)
                    {
                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            trainersAndPokemons[trainer].Remove(pokemon);
                            trainersAndBadgets[trainer].Pokemons--;
                        }
                    }
                }
            }
        }

        public static bool IsElementExist(Dictionary<string, List<Pokemon>> pokemons, string element)
        {
            foreach (var pokemon in pokemons)
            {
                foreach (var pokemonItem in pokemon.Value)
                {
                    if (pokemonItem.Element == element)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
