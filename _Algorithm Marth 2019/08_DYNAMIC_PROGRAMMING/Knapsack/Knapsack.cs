using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    class Knapsack
    {
        static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var items = new List<Item>();

            while (true)
            {
                string[] line = Console.ReadLine().Split();
                
                if (line[0] == "end")
                {
                    break;
                }

                string name = line[0];
                int weight = int.Parse(line[1]);
                int value = int.Parse(line[2]);

                items.Add(new Item {Name = name, Weight = weight, Price = value });
            }

            var prices = new int[items.Count + 1, maxCapacity + 1];
            var itemsIncluded = new bool[items.Count + 1, maxCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var item = items[itemIndex];
                int rowIndex = itemIndex + 1;

                for (int capacity = 0; capacity <= maxCapacity; capacity++)
                {
                    if (item.Weight > capacity)
                    {
                        continue;
                    }

                    int excludingPrice = prices[rowIndex - 1, capacity];
                    int includingPrice = item.Price 
                        + prices[rowIndex - 1, capacity - item.Weight];

                    if (includingPrice > excludingPrice)
                    {
                        prices[rowIndex, capacity] = includingPrice;
                        itemsIncluded[rowIndex, capacity] = true;
                    }
                    else
                    {
                        prices[rowIndex, capacity] = excludingPrice;
                    }
                }
            }          

            int currentCapacity = maxCapacity;           

            var result = new List<Item>();

            for (int itemIndex = items.Count - 1; itemIndex >= 0; itemIndex--)
            {              
                if (itemsIncluded[itemIndex + 1, currentCapacity])
                {
                    var currentItem = items[itemIndex];
                    result.Add(currentItem);

                    currentCapacity -= currentItem.Weight;
                }
            }

            Console.WriteLine($"Total Weight: {result.Sum(i => i.Weight)}");

            Console.WriteLine($"Total Value: {prices[items.Count, maxCapacity]}");
        }
    }
}
