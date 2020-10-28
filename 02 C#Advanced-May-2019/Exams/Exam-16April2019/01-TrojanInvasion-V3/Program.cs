using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TrojanInvasion_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesTrojanWarriors = int.Parse(Console.ReadLine());

            Queue<int> platesOfTheSpartanDefence = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int extraLine = wavesTrojanWarriors / 3;

            for (int i = 1; i <= wavesTrojanWarriors + extraLine; i++)
            {
                Stack<int> trojanWarriorPowers = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    platesOfTheSpartanDefence.Enqueue(extraPlate);

                    i++;
                }

                int currentSpartanPlates = platesOfTheSpartanDefence.Peek();
                int currentTrojanWarriorPower = trojanWarriorPowers.Peek();

                while (true)
                {
                    if (currentTrojanWarriorPower < currentSpartanPlates)
                    {
                        currentSpartanPlates -= currentTrojanWarriorPower;
                        trojanWarriorPowers.Pop();
                        currentTrojanWarriorPower = trojanWarriorPowers.Peek();
                    }
                    else if (currentTrojanWarriorPower == currentSpartanPlates)
                    {
                        trojanWarriorPowers.Pop();
                        platesOfTheSpartanDefence.Dequeue();
                    }
                    else if (currentTrojanWarriorPower > currentSpartanPlates)
                    {
                        currentTrojanWarriorPower -= currentSpartanPlates;
                        platesOfTheSpartanDefence.Dequeue();
                    }

                    if (trojanWarriorPowers.Count == 0)
                    {
                        break;
                    }

                    if (platesOfTheSpartanDefence.Count == 0)
                    {
                        Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
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
