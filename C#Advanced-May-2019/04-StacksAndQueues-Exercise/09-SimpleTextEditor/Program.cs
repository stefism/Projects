using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09_SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Stack<string> undoes = new Stack<string>();

            string @string = string.Empty;

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("1"))
                {
                    string[] splitedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string textToAdd = splitedCommand[1];

                    undoes.Push(@string);
                    @string += textToAdd;
                }

                else if (command.StartsWith("3"))
                {
                    string[] splitedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int index = int.Parse(splitedCommand[1]) - 1;

                    if (index >= 0 && index < @string.Length)
                    {
                        Console.WriteLine(@string[index]);
                    }
                }

                else if (command.StartsWith("2"))
                {
                    undoes.Push(@string);

                    string[] splitedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int elementToErase = int.Parse(splitedCommand[1]);

                    if (elementToErase > @string.Length)
                    {
                        @string = @string.Remove(0);
                    }
                    else
                    {
                        @string = @string.Remove(@string.Length - elementToErase);
                    }
                }

                else if (command.StartsWith("4"))
                {
                    if (undoes.Count > 0)
                    {
                        @string = undoes.Pop();
                    }
                }
            }
        }
    }
}
