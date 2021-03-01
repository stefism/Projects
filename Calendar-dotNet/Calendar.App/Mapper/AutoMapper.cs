using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Calendar.App.Mapper
{
    public static class ConfigureAutoMapperServices
    {
        public static IMapper ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddCollectionMappers();
                configuration.AddMaps(typeof(ConfigureAutoMapperServices).Assembly);
            });

            var mapper = config.CreateMapper();

            config.AssertConfigurationIsValid();
            services?.TryAddSingleton(mapper);

            return mapper;
        }
    }
}