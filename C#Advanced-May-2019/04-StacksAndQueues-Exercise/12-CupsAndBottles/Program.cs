using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> filledBottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedLitters = 0;

            while (cupsCapacity.Count != 0)
            {
                if (filledBottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                    return;
                }

                int currentBottleValue = filledBottles.Pop();
                int currentCupCapacity = cupsCapacity.Peek();

                if (currentBottleValue >= currentCupCapacity)
                {
                    cupsCapacity.Dequeue();
                    wastedLitters += currentBottleValue - currentCupCapacity;
                }
                else
                {
                    while (true)
                    {
                        currentCupCapacity -= currentBottleValue;

                        if (currentCupCapacity <= 0)
                        {
                            cupsCapacity.Dequeue();
                            wastedLitters += Math.Abs(currentCupCapacity);
                            break;
                        }

                        currentBottleValue = filledBottles.Pop();

                        
                    }
                }
            }

            Console.WriteLine($"Bottles: {string.Join(" ", filledBottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
