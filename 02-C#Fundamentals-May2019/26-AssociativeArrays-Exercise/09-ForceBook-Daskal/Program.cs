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

                input = Console.ReadLine();
            }
        }
    }
}
