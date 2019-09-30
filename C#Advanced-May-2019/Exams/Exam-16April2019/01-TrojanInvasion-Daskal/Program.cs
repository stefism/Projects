using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TrojanInvasion_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] platesList = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> platesQueue = new Queue<int>(platesList);

            for (int i = 1; i <= n; i++)
            {
                int[] warriorsList = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Stack<int> warriorsStack = new Stack<int>(warriorsList);

                if (i % 3 == 0)
                {
                    int additoinalPlate = int.Parse(Console.ReadLine());
                    platesQueue.Enqueue(additoinalPlate);
                }

                while (warriorsStack.Count > 0 && platesQueue.Count > 0)
                {
                    int currentWarrior = warriorsStack.Pop();
                    int currentPlate = platesQueue.Dequeue();

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriorsStack.Push(currentWarrior);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                    }
                }
            }
        }
    }
}
