using AutoMapper;
using LinqDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LinqDemo.Program;

namespace AutoMappingObject
{
    public class Demos
    {
        public static void Demos1()
        {
            var service = new ArtistService(new MusicXContext());
            var artists = service.GetAllWithCount();
            PrintArtist(artists);
            PrintArtistWithJson(artists);

            var db = new MusicXContext();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artists, ArtistWithCount>();
            });

            IMapper mapper = config.CreateMapper();

            Artists artist = db.Artists.FirstOrDefault();

            ArtistWithCount artistViewModel
                = mapper.Map<ArtistWithCount>(artist);
            Print(artistViewModel);

            var songs = db.Artists.Select(a => new ArtistWithCount
            {
                Name = a.Name,
                SongArtistsCount = a.SongArtists.Count
            }).ToList();
        }
        
        public static void Print1(IEnumerable<ArtistWithCount> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine($"~~{artist.Name}~~ => {artist.SongArtistsCount} song{(artist.SongArtistsCount != 1 ? "s" : string.Empty)}");
            }
        }

        //View(01)
        public static void PrintArtist(IEnumerable<ArtistWithCount> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine($"~~{artist.Name}~~ => {artist.SongArtistsCount} song{(artist.SongArtistsCount != 1 ? "s" : string.Empty)}");
            }
        }

        //View(02)
        public static void PrintArtistWithJson(IEnumerable<ArtistWithCount> artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented));
        }
    }
}
