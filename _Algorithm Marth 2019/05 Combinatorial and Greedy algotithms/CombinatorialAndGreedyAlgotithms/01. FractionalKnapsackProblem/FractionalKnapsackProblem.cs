using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._FractionalKnapsackProblem
{
    class Item
    {
        internal double Price { get; set; }

        internal double Weight { get; set; }

        internal double PriceWeightRatio => Weight / Price;
    }

    class FractionalKnapsackProblem
    {
        private static List<Item> allItems = new List<Item>();

        private static double totalPrice;

        private static double capacity;

        private static StringBuilder output = new StringBuilder();

        static void Main(string[] args)
        {
            ReadInput();

            allItems = allItems.OrderBy(i => i.PriceWeightRatio).ToList();

            double freeCapacity = capacity;
            CalculateOutput(freeCapacity);

            Console.WriteLine(output.ToString());
        }

        private static void CalculateOutput(double freeCapacity)
        {
            foreach (var item in allItems)
            {
                if (item.Weight <= freeCapacity)
                {
                    freeCapacity -= item.Weight;
                    totalPrice += item.Price;
                    output.AppendLine($"Take 100% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                }
                else if (item.Weight > freeCapacity || freeCapacity > 0)
                {
                    var percentageOfItem = freeCapacity / item.Weight * 100;
                    var partPrice = item.Price * percentageOfItem / 100;
                    totalPrice += partPrice;
                    output.AppendLine($"Take {percentageOfItem:F2}% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                    output.AppendLine($"Total price: {totalPrice:F2}");
                    break;
                }
            }           
        }

        private static void ReadInput()
        {
            var capacityInput = Console.ReadLine().Split();
            var itemsInput = Console.ReadLine().Split();

            capacity = double.Parse(capacityInput[1]);
            var items = double.Parse(itemsInput[1]);

            for (int i = 0; i < items; i++)
            {
                var input = Console.ReadLine().Split(" -> ");

                allItems.Add(new Item
                {
                    Price = double.Parse(input[0]),
                    Weight = double.Parse(input[1]),
                });
            }
        }
    }
}
