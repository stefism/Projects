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

                    @string += textToAdd;
                    undoes.Push(@string);
                }

                else if (command.StartsWith("3"))
                {
                    string[] splitedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int index = int.Parse(splitedCommand[1]);

                    Console.WriteLine(@string[index-1]);
                }

                else if (command.StartsWith("2"))
                {
                    string[] splitedCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int elementToErase = int.Parse(splitedCommand[1]);

                    @string = @string.Remove(elementToErase - @string.Length);
                    //undoes.Push(@string);
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
