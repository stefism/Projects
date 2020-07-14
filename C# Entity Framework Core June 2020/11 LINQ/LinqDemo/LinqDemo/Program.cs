using LinqDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;

namespace LinqDemo
{
    class Program
    {
        // Z.EntityFramework.Plus.EFCore - за групово триене или ъпдейтване.
        // context.Employees
        //.Where(u => u.FirstName == "Pesho")
        //.Delete();
        static void Main(string[] args)
        {
            using var dbContext = new MusicXContext();

            //Song1Demo(dbContext);

            //BachUpdateAndDelete(dbContext);

            //ExplicitLoading(dbContext);

            // Eager loading
            var song = dbContext.Songs
                .Include(x => x.Source)
                .Include(x => x.SongArtists)
                .ThenInclude(sa => sa.Artist) // Добавя още едно ниво навътре на свързване. Зарежда пропертито на пропертито.
                .Where(s => s.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            //---
            var songs2 = dbContext.Songs
                .Where(s => s.SongArtists.Count > 2)
                .Select(s => new
                {
                    s.Name,
                    Artists = s.SongArtists.Select(s => s.Artist.Name)
                }).Take(10).ToList();



            //CustomJoin(dbContext);

            foreach (var s in songs2)
            {
                Console.WriteLine(string.Join(", ", s.Artists) + " - " + song.Name);

                /* - Output:
                C.Aguilera, Mya, Pink - Lady Marmalade
                Rose Lorens, Sophie Delmas, Hanna H - Pour Aimer Plus Fort
                Sargue, P.D' Avilla, G. Baquet - On Dit Dans La Rue
                Old Fashioned Way, Snoop Dogg, Tha Eastsidaz - Duces 'n Trayz
                Max Brothers, Kanui, Lul -Oua Oua
                Nate Dogg, Kurupt, Shade Sheist -Where I Wanna Be
                DJ Luck, MC Neat, Ari Gold - I'm All About You
                Ja Rule, Lil' Mo, Vita - Put It On Me
                Kandi, Sole, J.t.Money - 4,5,6
                Mariah Carey, Joe, 98 Degrees - Thank God I Foound You
                */
            }
        }

        private static void ExplicitLoading(MusicXContext dbContext)
        {
            //Explicit Loading
            var song = dbContext.Songs
                .Where(s => s.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();
            dbContext.Entry(song).Reference(s => s.Source).Load(); // Зарежда експлицитно и Source към Songs. Това е когато е проперти. Когато е ICollection се използва .Collection за да го зареди:
            dbContext.Entry(song).Collection(s => s.SongMetadata).Load(); // Ето така.
                                                                          // Explicit Loading работи само върху едно ентити. (Върху един обект). (var song). Не работи върху колекция от песни (обекти). Примерно (songs).
        }

        private static void BachUpdateAndDelete(MusicXContext dbContext)
        {
            dbContext.SongMetadata.Where(x => x.SongId >= 10).Delete();

            dbContext.Songs.Where(s => s.Name.Contains("а") || s.Name.Contains("е")).Update(song => new Songs { Name = song.Name + " (BG)" });
        }

        private static void CustomJoin(MusicXContext dbContext)
        {
            //Ръчно джойнване.
            // SELECT 
            // FROM Songs songs
            // JOIN Sources sources ON songs.SourceId = sources.Id
            var joinSongsWithSources =
                dbContext.Songs.Join(dbContext.Sources,
                                                          songs => songs.SourceId,
                                                          sources => sources.Id,
                                                          (songs, sources) => new
                                                          {
                                                              SongName = songs.Name,
                                                              SourceName = sources.Name
                                                          }).ToList();
            // Не се прави така, но ако все пак.
            // Същото но с линку:
            var joinedSongs = dbContext.Songs
                .Select(s => new
                {
                    SongName = s.Name,
                    SourceName = s.Source.Name
                })
                .ToList();
        }

        private static void Song1Demo(MusicXContext dbContext)
        {
            var songs = dbContext.Songs
                //.Include(s => s.Source) -> Ако искаме да джойнеме без селект се ползва .Include метода и му се казва коя колона да добави. Не се препоръчва особено все пак.
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
