using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            //string inputpr = Console.ReadLine().Replace(Environment.NewLine, " ");
            //List<string> input = Console.ReadLine().Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var minerals = new Dictionary<string, int>();

            // Пълниме minerals със всички входни елементи и техните стойности.

            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
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

                        // Проверяваме за текущия ред дали не е станало >= 250
                        if (minerals.ContainsKey("shards"))
                        {
                            if (minerals["shards"] >= 250)
                            {
                                break;
                            }
                        }

                        if (minerals.ContainsKey("fragments"))
                        {
                            if (minerals["fragments"] >= 250)
                            {
                                break;
                            }
                        }

                        if (minerals.ContainsKey("motes"))
                        {
                            if (minerals["motes"] >= 250)
                            {
                                break;
                            }
                        }
                    }

                    // Правим проверка дали някой legendaryItems >= 250
                    // Ако е да, спираме цикъла, отпечатваме итема и ако е стойността е по-голяма от 250,
                    // трябва да извадим 250 от съответната натрупана стойност.
                }
                if (minerals.ContainsKey("shards"))
                {
                    if (minerals["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        minerals["shards"] -= 250;
                        break;
                    }
                }

                if (minerals.ContainsKey("fragments"))
                {
                    if (minerals["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        minerals["fragments"] -= 250;
                        break;
                    }
                }

                if (minerals.ContainsKey("motes"))
                {
                    if (minerals["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        minerals["motes"] -= 250;
                        break;
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

            // На следващите три реда отпечатайте останалите ключови материали в низходящ ред по количество
            // два ключови материала имат едно и също количество, отпечатайте ги по азбучен ред.

            // Печатаме ключовите материали и след тях, печатим осналите с два foreach цикъла.

            var ordered = legendaryItems.OrderByDescending(a => a.Value).ThenBy(b => b.Key);

            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            var orderedMinerals = minerals.OrderBy(a => a.Key);

            foreach (var item in orderedMinerals)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
