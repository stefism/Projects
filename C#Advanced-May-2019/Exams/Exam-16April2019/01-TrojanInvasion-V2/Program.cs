using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TrojanInvasion_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesTrojanWarriors = int.Parse(Console.ReadLine());

            List<int> platesOfTheSpartanDefence = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> trojanWarriorPowers = new List<int>();

            //int extraLine = wavesTrojanWarriors / 3;

            for (int i = 1; i <= wavesTrojanWarriors; i++)
            {
                trojanWarriorPowers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    platesOfTheSpartanDefence.Add(extraPlate);

                    //i++;
                }

                while (true)
                {
                    if (trojanWarriorPowers[trojanWarriorPowers.Count-1] < platesOfTheSpartanDefence[0])
                    {
                        platesOfTheSpartanDefence[0] -= trojanWarriorPowers[trojanWarriorPowers.Count - 1];
                        trojanWarriorPowers.RemoveAt(trojanWarriorPowers.Count - 1);
                    }
                    else if (trojanWarriorPowers[trojanWarriorPowers.Count - 1] == platesOfTheSpartanDefence[0])
                    {
                        trojanWarriorPowers.RemoveAt(trojanWarriorPowers.Count - 1);
                        platesOfTheSpartanDefence.RemoveAt(0);
                    }
                    else if (trojanWarriorPowers[trojanWarriorPowers.Count - 1] > platesOfTheSpartanDefence[0])
                    {
                        trojanWarriorPowers[trojanWarriorPowers.Count - 1] -= platesOfTheSpartanDefence[0];
                        platesOfTheSpartanDefence.RemoveAt(0);
                    }

                    if (trojanWarriorPowers.Count == 0)
                    {
                        break;
                    }

                    if (platesOfTheSpartanDefence.Count == 0)
                    {
                        Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                        trojanWarriorPowers.Reverse();
                        Console.WriteLine($"Warriors left: {string.Join(", ", trojanWarriorPowers)}");
                        return;
                    }
                }
            }

            if (platesOfTheSpartanDefence.Count > 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfTheSpartanDefence)}");
            }
        }
    }
}
