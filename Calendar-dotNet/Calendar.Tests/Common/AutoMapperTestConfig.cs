using AutoMapper;
using Calendar.App.Mapper;

namespace Calendar.Tests.Common
{
    public static class AutoMapperTestConfig
    {
        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddMaps(typeof(ConfigureAutoMapperServices).Assembly);
            });

            return config.CreateMapper();
        }
    }
}
