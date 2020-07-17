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
            });
           
            var db = new MusicXContext();           

            ArtistWithCount artistViewModel = db.Artists.Where(x => x.Id == 10)
                .ProjectTo<ArtistWithCount>(config).FirstOrDefault();
            Print(artistViewModel);           
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
