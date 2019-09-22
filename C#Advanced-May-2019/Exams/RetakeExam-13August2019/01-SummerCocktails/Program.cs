using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var cocktailsInfo = new SortedDictionary<string, int>
            {
                { "Mimosa", 150 },
                { "Daiquiri", 250 },
                { "Sunshine", 300 },
                { "Mojito", 400 }
            };

            var makedCocktails = new SortedDictionary<string, int>();

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (freshnessLevel.Count > 0 && ingredients.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int cocktailsValue = ingredients.Peek() * freshnessLevel.Peek();

                if (cocktailsInfo.ContainsValue(cocktailsValue))
                {
                    string cocktailName = cocktailsInfo.FirstOrDefault(x => x.Value == cocktailsValue).Key;

                    if (!makedCocktails.ContainsKey(cocktailName))
                    {
                        makedCocktails.Add(cocktailName, 0);
                    }

                    makedCocktails[cocktailName]++;

                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }

                else
                {
                    freshnessLevel.Pop();
                    int ingredientsValue = ingredients.Dequeue();
                    ingredientsValue += 5;
                    ingredients.Enqueue(ingredientsValue);
                }
            }

            if (makedCocktails.ContainsKey("Mimosa") && makedCocktails.ContainsKey("Daiquiri")
                && makedCocktails.ContainsKey("Sunshine") && makedCocktails.ContainsKey("Mojito"))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Count > 0)
            {
                int sum = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {sum}");
            }

            foreach (var cocktail in makedCocktails)
            {
                Console.WriteLine($"# {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}
