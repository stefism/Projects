using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Songs> songs = new List<Songs>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputSong = Console.ReadLine().Split("_");

                string type = inputSong[0];
                string name = inputSong[1];
                string time = inputSong[2];

                Songs currentSong = new Songs();

                currentSong.TypeList = type;
                currentSong.Name = name;
                currentSong.Time = time;

                songs.Add(currentSong);
            }

            string typeList = Console.ReadLine();


            if (typeList == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }


            // You can use LINQ to filter the collection.
            // Този ред прави същото както горните.

            //List<Songs> filteredSongs = songs.Where(s => s.TypeList == typeList).ToList();

            //foreach (var song in filteredSongs)
            //{
            //    Console.WriteLine(song.Name);
            //}
        }
    }

    class Songs
    {
        public string TypeList;
        public string Name;
        public string Time;
    }
}
