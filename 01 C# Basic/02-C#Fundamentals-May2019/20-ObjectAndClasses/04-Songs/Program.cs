using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>();

            for (int i = 0; i < songsNumber; i++)
            {
                Song songs = new Song();
                List<string> currentSong = Console.ReadLine().Split("_").ToList();
                songs.TypeList = currentSong[0];
                songs.Name = currentSong[1];
                songs.Time = currentSong[2];
                allSongs.Add(songs);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var item in allSongs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (var item in allSongs)
                {
                    if (item.TypeList == typeList)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        public string TypeList;
        public string Name;
        public string Time;
    }
}
