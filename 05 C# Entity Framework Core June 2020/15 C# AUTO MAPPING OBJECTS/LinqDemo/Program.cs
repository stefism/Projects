using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMappingObject;
using LinqDemo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;

namespace LinqDemo
{
    public class Program
    {

        static void Main(string[] args)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artists, ArtistWithCount>();
                cfg.AddProfile(new SongsToViewModelProfile());
            });

            // .ReverseMap() се ползва когато искаме от вю модел да направиме клас, който после да вкараме в базата. Примерно когато потребителя е въвел нова песен от приложението, тя после за да се вкара в базата трябва да се обърне на клас, който го има в db контекста.

            var db = new MusicXContext();

            ArtistWithCount artistViewModel = db.Artists.Where(x => x.Id == 10)
                //.Select(x => new ArtistWithCount 
                //{
                //    Name = x.Name,
                //    CreatedOn = x.CreatedOn,
                //    ModifiedOn = x.ModifiedOn,
                //    SongArtistsCount = x.SongArtists.Count,
                //})
                .ProjectTo<ArtistWithCount>(config).FirstOrDefault(); // Този ред .ProjectTo, спестява всичкото писане на горното и ръчното мапване.
            Print(artistViewModel);

            var artists = db.Songs.ProjectTo<SongViewModel>(config)
                .Take(10).ToList();
            Print(artists);
            //ReverseMap(config, db);
        }

        private static void ReverseMap(MapperConfiguration config, MusicXContext db)
        {
            //Reverse Map:
            var input = new SongViewModel
            {
                Name = "Test 1234",
                SourceName = "VBox7"
            };

            var mapper = config.CreateMapper();
            var inputSong = mapper.Map<Songs>(input);
            db.Songs.Add(inputSong);
            db.SaveChanges();
            //Reverse Map.
        }

        public static void Print(object artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented));
        }
        
        public class ArtistWithCount // DTO - Data Transfer Object
        {
            public string Name { get; set; }

            public DateTime CreatedOn { get; set; }

            public DateTime? ModifiedOn { get; set; }

            public int SongArtistsCount { get; set; } //Това е същото като навигационното проперти, отзад с Count и дава автоматично бройката на песните.
        }
    }
}
