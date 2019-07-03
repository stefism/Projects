using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            var minerals = new Dictionary<string, int>();

            // Пълниме minerals със всички входни елементи и техните стойности.

            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 1)
                {
                    string currentMineral = input[i].ToLower();
                    int currentValue = int.Parse(input[i - 1]);

                    if (!minerals.ContainsKey(currentMineral))
                    {
                        minerals[currentMineral] = currentValue;
                    }

                    else
                    {
                        minerals[currentMineral] += currentValue;
                    }
                }
            }

            // Създаваме речник legendaryItems в който слагаме само легендарните итеми.

            var legendaryItems = new Dictionary<string, int>();

            foreach (var item in minerals)
            {
                if (item.Key == "shards" || item.Key == "fragments" || item.Key == "motes")
                {
                    legendaryItems[item.Key] = item.Value;
                }
            }

            // Премахваме от minerals легендарните итеми, ако ги има.

            if (minerals.ContainsKey("shards"))
            {
                minerals.Remove("shards");
            }
            
            if (minerals.ContainsKey("fragments"))
            {
                minerals.Remove("fragments");
            }
           
            if (minerals.ContainsKey("motes"))
            {
                minerals.Remove("motes");
            }

            // Проверяваме дали в legendaryItems има легендарни минерали и
            // ако нямя, добавяме такива със стойност 0.

            if (!legendaryItems.ContainsKey("shards"))
            {
                legendaryItems["shards"] = 0;
            }

            if (!legendaryItems.ContainsKey("fragments"))
            {
                legendaryItems["fragments"] = 0;
            }

            if (!legendaryItems.ContainsKey("motes"))
            {
                legendaryItems["motes"] = 0;
            }

            // Ако някой от легендарните има стойност >= 250, печатиме и
            // изваждаме от него тази стойност (250).

            if (legendaryItems["shards"] >= 250)
            {
                Console.WriteLine($"Shadowmourne obtained!");
                legendaryItems["shards"] -= 250;
            }

            if (legendaryItems["fragments"] >= 250)
            {
                Console.WriteLine($"Valanyr obtained!");
                legendaryItems["fragments"] -= 250;
            }

            if (legendaryItems["motes"] >= 250)
            {
                Console.WriteLine($"Dragonwrath obtained!");
                legendaryItems["motes"] -= 250;
            }

            // Отпечатваме легендарните по зададените критерии.
            // (подредени по количество в низходящ ред, след това 
            // по име във възходящ ред, всеки на нов ред).
            // На следващите три реда отпечатайте останалите ключови материали в низходящ ред по количество
            // два ключови материала имат едно и също количество, отпечатайте ги по азбучен ред

            var ordered = legendaryItems.OrderByDescending(a => a.Value).ThenBy(b => b.Key);
        }
    }
}
