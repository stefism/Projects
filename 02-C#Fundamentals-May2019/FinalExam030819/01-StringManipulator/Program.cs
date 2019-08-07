using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _01_StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Done")
                {
                    break;
                }

                string[] commands = command.Split();

                string currentCommand = commands[0];

                if (currentCommand == "Change")
                {
                    string currentChar = commands[1];
                    string replacement = commands[2];

                    input = input.Replace(currentChar, replacement);
                    Console.WriteLine(input);
                }

                else if (currentCommand == "Includes")
                {
                    string includes = commands[1];

                    if (input.Contains(includes))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (currentCommand == "End")
                {
                    string endString = commands[1];

                    if (input.EndsWith(endString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (currentCommand == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }

                else if (currentCommand == "FindIndex")
                {
                    string findChar = commands[1];

                    int index = input.IndexOf(findChar);

                    Console.WriteLine(index);
                }

                else if (currentCommand == "Cut")
                {
                    int startIndex = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    input = input.Substring(startIndex, length);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
