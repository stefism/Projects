using Calendar.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Tests.Common
{
    public static class InMemoryContextHelpers
    {
        public static ApplicationDbContext GetCleanInMemoryDbContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: "DbInMemory")
                .UseInternalServiceProvider(serviceProvider);

            var dbContextOptions = builder.Options;
            var context = new ApplicationDbContext(dbContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
