using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesTrojanWarriors = int.Parse(Console.ReadLine());

            Queue<int> platesOfTheSpartanDefence
                = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> trojanWarriorPowers = new Stack<int>();

            int extraLine = wavesTrojanWarriors / 3;

            for (int i = 1; i <= wavesTrojanWarriors + extraLine; i++)
            {
                int[] currentTrojanPowers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());

                    platesOfTheSpartanDefence.Enqueue(extraPlate);
                    i++;
                }

                for (int j = 0; j < currentTrojanPowers.Length; j++)
                {
                    trojanWarriorPowers.Push(currentTrojanPowers[j]);
                }
                
                int currentSpartanPlates = platesOfTheSpartanDefence.Dequeue();
                int currentTrojanWarriorPower = trojanWarriorPowers.Pop();

                while (trojanWarriorPowers.Count != 0 || platesOfTheSpartanDefence.Count == 0)
                {
                    while (true)
                    {
                        if (currentTrojanWarriorPower > currentSpartanPlates)
                        {
                            currentTrojanWarriorPower -= currentSpartanPlates;

                            if (platesOfTheSpartanDefence.Count == 0)
                            {
                                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                                Console.Write("Warriors left: ");

                                if (currentTrojanWarriorPower > 0)
                                {
                                    Console.WriteLine($"{currentTrojanWarriorPower}, {string.Join(", ", trojanWarriorPowers)}");
                                }
                                else
                                {
                                    Console.WriteLine($"{string.Join(", ", trojanWarriorPowers)}");
                                }

                                return;
                            }

                            currentSpartanPlates = platesOfTheSpartanDefence.Dequeue();
                        }

                        else if (currentTrojanWarriorPower == currentSpartanPlates)
                        {
                            if (trojanWarriorPowers.Count == 0)
                            {
                                break;
                            }

                            currentSpartanPlates = platesOfTheSpartanDefence.Dequeue();
                            currentTrojanWarriorPower = trojanWarriorPowers.Pop();
                        }

                        else
                        {
                            currentSpartanPlates -= currentTrojanWarriorPower;

                            if (currentSpartanPlates == 0)
                            {
                                break;
                            }

                            currentTrojanWarriorPower = trojanWarriorPowers.Pop();
                        }
                    }
                }

                if (trojanWarriorPowers.Count == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine("Warriors left: {}");
                    break;
                }
            }

            if (trojanWarriorPowers.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfTheSpartanDefence)}");
            }
        }
    }
}
