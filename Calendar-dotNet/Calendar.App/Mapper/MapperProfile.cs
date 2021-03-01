using AutoMapper;
using Calendar.App.Data;
using Calendar.App.ViewModels;

namespace Calendar.App.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Date, ReservationViewModel>()
                .ForMember(dst => dst.ReservationDateId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price.ToString()));
        }
    }
}