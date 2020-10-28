using System;
using System.Linq;

namespace _01_StringManupulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                string command = commands[0];

                if (command == "End")
                {
                    break;
                }

                else if (command == "Add")
                {
                    string currentInput = commands[1];
                    input += currentInput;
                    //Console.WriteLine(input);
                }

                else if (command == "Print")
                {
                    Console.WriteLine(input);
                }

                else if (command == "Index")
                {
                    char currentChar = char.Parse(commands[1]);
                    bool isCharExist = false;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == currentChar)
                        {
                            Console.Write(i + " ");
                            isCharExist = true;
                        }
                    }

                    if (!isCharExist)
                    {
                        Console.WriteLine("None");
                    }

                    Console.WriteLine();
                }

                else if (command == "Upgrade")
                {
                    char currentChar = char.Parse(commands[1]);
                    string updatedString = string.Empty;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == currentChar)
                        {
                            updatedString += (char)(currentChar + 1);
                        }
                        else
                        {
                            updatedString += input[i];
                        }
                    }
                    input = updatedString;
                    ///Console.WriteLine(input);
                }

                else if (command == "Remove")
                {
                    string removedString = commands[1];

                    input = input.Replace(removedString, string.Empty);
                }
            }
        }
    }
}
