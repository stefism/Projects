using System;
using System.Linq;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int numberOfColors = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfColors; i++)
            {
                string[] currentInput = Console.ReadLine().Split(" -> ");

                string color = currentInput[0];
                string[] clothes = currentInput[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>(); 
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] searchedItems = Console.ReadLine().Split();

            string searchedColor = searchedItems[0];
            string searchedCloth = searchedItems[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == searchedColor && cloth.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
