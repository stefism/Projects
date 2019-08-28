using System;
using System.Linq;
using System.Collections.Generic;

namespace _11_PartyReservaionFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            List<char> startFilter = new List<char>();
            List<char> endFilter = new List<char>();

            while (true)
            {
                string commandLine = Console.ReadLine();

                if (commandLine == "Print")
                {

                    break;
                }

                if (commandLine.StartsWith("Add") && commandLine.Contains("Starts"))
                {
                    startFilter.Add(commandLine[commandLine.Length-1]);
                }
            }
        }
    }
}
