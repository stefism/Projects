using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SpaceshipCrafting
{
    class Program
    {
        static Dictionary<string, int> advancedMaterials = new Dictionary<string, int>
            {
                { "Aluminium", 0 },
                { "Carbon fiber", 0 },
                { "Glass", 0 },
                { "Lithium", 0 },
            };

        const int GLASS = 25;
        const int ALUMINIUM = 50;
        const int LITHIUM = 75;
        const int CARBON_FIBER = 100;

        static void Main(string[] args)
        {
            Queue<int> chemicalLiquids = new Queue<int>(Console.ReadLine()
                .Split().Select(int.Parse));

            Stack<int> physicalItems = new Stack<int>(Console.ReadLine()
                .Split().Select(int.Parse));

            while (chemicalLiquids.Count > 0 && physicalItems.Count > 0)
            {
                int currentChemicalLiquid = chemicalLiquids.Peek();
                int currentPhysicalItem = physicalItems.Peek();

                int sumOfItems = currentChemicalLiquid + currentPhysicalItem;

                if (sumOfItems == ALUMINIUM)
                {
                    advancedMaterials["Aluminium"]++;
                    RemoveUsedItems(chemicalLiquids, physicalItems);
                    continue;
                }
                else if (sumOfItems == CARBON_FIBER)
                {
                    advancedMaterials["Carbon fiber"]++;
                    RemoveUsedItems(chemicalLiquids, physicalItems);
                    continue;
                }
                else if (sumOfItems == GLASS)
                {
                    advancedMaterials["Glass"]++;
                    RemoveUsedItems(chemicalLiquids, physicalItems);
                    continue;
                }
                else if (sumOfItems == LITHIUM)
                {
                    advancedMaterials["Lithium"]++;
                    RemoveUsedItems(chemicalLiquids, physicalItems);
                    continue;
                }
                else
                {
                    chemicalLiquids.Dequeue();
                    currentPhysicalItem += 3;

                    physicalItems.Pop();
                    physicalItems.Push(currentPhysicalItem);
                }
            }

            if (advancedMaterials.Values.Sum() >= 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            Console.Write("Liquids left: ");
            Console.WriteLine(chemicalLiquids.Count == 0 ? "none" : string.Join(", ", chemicalLiquids));

            Console.Write("Physical items left: ");
            Console.WriteLine(physicalItems.Count == 0 ? "none" : string.Join(", ", physicalItems));

            foreach (var material in advancedMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }

        private static void RemoveUsedItems(Queue<int> chemicalLiquids, Stack<int> physicalItems)
        {
            chemicalLiquids.Dequeue();
            physicalItems.Pop();
        }
    }
}
