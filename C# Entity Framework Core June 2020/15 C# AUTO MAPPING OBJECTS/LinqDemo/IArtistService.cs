using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LinqDemo.Program;

namespace AutoMappingObject
{
    public interface IArtistService
    {
        IEnumerable<ArtistWithCount> GetAllWithCount();
    }

    class ArtistService : IArtistService
    {
        private readonly MusicXContext context;

        public ArtistService(MusicXContext context)
        {
            this.context = context;
        }

        public IEnumerable<ArtistWithCount> GetAllWithCount()
        {
            var artists = context.Artists.Select(a => new ArtistWithCount
            {
                Name = a.Name,
                SongArtistsCount = a.SongArtists.Count
            }).ToList();

            return artists;
        }
    }
}

