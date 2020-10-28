using System;

namespace SUS.MvcFramework
{
    public interface IServiceCollection //Dependency container
    {
        //.Add<IUserService, UserService>(); Connection between interfaces an clases.
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}
