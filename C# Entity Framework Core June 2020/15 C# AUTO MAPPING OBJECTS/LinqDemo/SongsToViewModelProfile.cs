using AutoMapper;
using LinqDemo;
using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMappingObject
{
    public class SongsToViewModelProfile : Profile
    {
        public SongsToViewModelProfile()
        {
            this.CreateMap<Songs, SongViewModel>()
                .ForMember(
                    svm => svm.Artists,
                    opt => opt.MapFrom(s =>
                    string.Join(", ", s.SongArtists.Select(x => x.Artist.Name))))
                .ForMember(
                    x => x.LastModified,
                    opt => opt.MapFrom(s =>
                    s.ModifiedOn ?? s.CreatedOn))// Ако ModifiedOn е null, използвай CreatedOn.
                .ReverseMap();
        }
    }
}
