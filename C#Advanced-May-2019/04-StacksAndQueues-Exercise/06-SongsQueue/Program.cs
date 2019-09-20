using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();

                string song = command.Replace("Add ", "");

                if (command.StartsWith("Add"))
                {
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }

                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                else if (command == "Play")
                {
                    if (songs.Count == 0)
                    {
                        break;
                    }

                    songs.Dequeue();
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
