using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ForceBook_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            var sideMembers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] splitedInput = input.Split(" | ");

                    string side = splitedInput[0];
                    string memberName = splitedInput[1];

                    if (!sideMembers.ContainsKey(side))
                    {
                        sideMembers[side] = new List<string>();
                    }

                    bool memberExist = false;

                    foreach (var kvp in sideMembers)
                    {
                        if (kvp.Value.Contains(memberName))
                        {
                            memberExist = true;
                            break;
                        }
                    }

                    if (!sideMembers[side].Contains(memberName) && !memberExist)
                    {
                        sideMembers[side].Add(memberName);
                    }
                }

                else
                {
                    string[] splitedInput = input.Split(" -> ");

                    string memberName = splitedInput[0];
                    string side = splitedInput[1];

                    bool memberExist = false;
                    string currentSide = "";

                    foreach (var kvp in sideMembers)
                    {
                        if (kvp.Value.Contains(memberName))
                        {
                            memberExist = true;
                            currentSide = kvp.Key;
                            break;
                        }
                    }

                    if (memberExist)
                    {
                        sideMembers[currentSide].Remove(memberName);
                    }

                    if (!sideMembers.ContainsKey(side))
                    {
                        sideMembers[side] = new List<string>();
                    }

                    if (!sideMembers[side].Contains(memberName))
                    {
                        sideMembers[side].Add(memberName);
                    }

                    Console.WriteLine($"{memberName} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            sideMembers = sideMembers.Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sideMembers)
            {
                string sideName = kvp.Key;
                List<string> sidesMembers = kvp.Value;
                sidesMembers.Sort();

                Console.WriteLine($"Side: {sideName}, Members: {sidesMembers.Count}");

                foreach (var member in sidesMembers)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
