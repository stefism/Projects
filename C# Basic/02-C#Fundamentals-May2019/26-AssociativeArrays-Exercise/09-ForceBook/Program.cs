using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var sides = new Dictionary<string, List<string>>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "Lumpawaroo")
                {
                    sides = sides.OrderByDescending(x => x.Value.Count)
                        .ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var item in sides)
                    {
                        item.Value.Sort();
                    }    

                    foreach (var item in sides)
                    {
                        if (item.Value.Count > 0)
                        {
                            Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                            Console.WriteLine("! " + string.Join(Environment.NewLine + "! ", item.Value));
                        }
                    }
                    break;
                }

                if (commands.Contains("|"))
                {
                    string[] splitedCommands = commands.Split(" | ");
                    string side = splitedCommands[0];
                    string name = splitedCommands[1];

                    if (!sides.ContainsKey(side))
                    {
                        sides[side] = new List<string>();
                    }

                    bool isMemberExist = false;

                    foreach (var item in sides)
                    {
                        if (item.Value.Contains(name))
                        {
                            isMemberExist = true;
                            break;
                        }
                    }

                    if (!sides[side].Contains(name) && !isMemberExist)
                    {
                        sides[side].Add(name);
                    }
                }

                else if (commands.Contains("->"))
                {
                    string[] splitedCommands = commands.Split(" -> ");
                    string name = splitedCommands[0];
                    string side = splitedCommands[1];

                    foreach (var item in sides)
                    {
                        if (item.Value.Contains(name))
                        {
                            item.Value.Remove(name);
                            break;
                        }
                    }

                    if (sides.ContainsKey(side))
                    {
                        sides[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }

                    if(!sides.ContainsKey(side))
                    {
                        sides[side] = new List<string>();
                        sides[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                }
            }
        }
    }
}
