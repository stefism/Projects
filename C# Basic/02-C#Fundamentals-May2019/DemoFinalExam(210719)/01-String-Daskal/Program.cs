using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_String_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitedInput = input.Split();

                string command = splitedInput[0];

                if (command == "Add")
                {
                    string newStringToAdd = splitedInput[1];

                    result += newStringToAdd;
                }

                else if (command == "Upgrade")
                {
                    char oldChar = char.Parse(splitedInput[1]);
                    result = result.Replace(oldChar, (char)(oldChar+1));
                }

                else if (command == "Print")
                {
                    Console.WriteLine(result);
                }

                else if (command == "Index")
                {
                    // Алтернативно решение на долното:
                    List<int> indexes = new List<int>();

                    char symbol = char.Parse(splitedInput[1]);

                    indexes = result.Select((x, i) => i)
                        .Where(i => result[i] == symbol)
                        .ToList();

                    Console.WriteLine(string.Join(" ", indexes));
                    
                    //char symbol = char.Parse(splitedInput[1]);

                    //bool isSymbolExist = false;

                    //for (int i = 0; i < result.Length; i++)
                    //{
                    //    char currentSymbol = result[i];

                    //    if (currentSymbol == symbol)
                    //    {
                    //        Console.Write(i + " ");
                    //        isSymbolExist = true;
                    //    }
                    //}

                    //if (!isSymbolExist)
                    //{
                    //    Console.WriteLine("None");
                    //}
                }

                else if (command == "Remove")
                {
                    string searchedStr = splitedInput[1];

                    while (result.Contains(searchedStr))
                    {
                        int index = result.IndexOf(searchedStr);
                        result = result.Remove(index, searchedStr.Length);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
