using System;
using System.Linq;
using System.Collections.Generic;

namespace _10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "Party!")
                {
                    break;
                }

                string command = commands[0];
                string commandParam = commands[1];
                string commandString = commands[2];

                List<string> returnedNames = ReturnNamesWithGivenCriteria
                        (commandParam, commandString, names);

                if (command == "Double")
                {
                    if (returnedNames != null)
                    {
                        foreach (var name in returnedNames)
                        {
                            int nameIndex = names.IndexOf(name);

                            names.Insert(nameIndex+1, name); // Ако е последно тука може да гръмне.
                        }
                    }
                }

                else if (command == "Remove")
                {
                    if (returnedNames != null)
                    {
                        for (int i = 0; i < returnedNames.Count; i++)
                        {
                            names.RemoveAll(x => x == returnedNames[i]);
                        }
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> ReturnNamesWithGivenCriteria
            (string commandParam, string commandString, List<string> names)
        {
            if (commandParam == "StartsWith")
            {
                List<string> startsWith = names.Where(x => x.StartsWith(commandString)).ToList();
                return startsWith;
            }

            else if (commandParam == "EndsWith")
            {
                List<string> endsWith = names.Where(x => x.EndsWith(commandString)).ToList();
                return endsWith;
            }

            else if (commandParam == "Length")
            {
                int lenght = int.Parse(commandString);

                List<string> namesWithGivenLength = names
                    .Where(x => x.Length == lenght).ToList();
                return namesWithGivenLength;
            }

            return null;
        }
    }
}
