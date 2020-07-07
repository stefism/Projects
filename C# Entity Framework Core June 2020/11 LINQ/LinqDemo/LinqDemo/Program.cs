using LinqDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           using var dbContext = new MusicXContext();

            var songs = dbContext.Songs
                //.Include(s => s.Source) -> Ако искаме да джойнеме без селект се ползва .Include метода и му се казва коя колона да добави.
                .Select(s => new SongsProjection 
                { 
                    Name = s.Name,
                    SourceName = s.Source.Name
                })
                .OrderBy(s => s.Name)
                .Where(s => s.SourceName == "User")
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name + " => " + song.SourceName);
            }
        }
      
        private static void Examples()
        {
            List<string> list = new List<string> { "Niki", "Pesho", "Stoyan", "Ani", "Viktor" };

            var list2 = list.Where(x => x.Length <= 4);
            var list2a = list.Where(Predicate).OrderBy(x => x);

            foreach (var item in list2a)
            {
                Console.WriteLine(item);
            }
        }

        static bool Predicate(string x)
        {
            return x.Length <= 4;
        }
    }

    class SongsProjection
    {
        public string Name { get; set; }

        public string SourceName { get; set; }
    }
}
