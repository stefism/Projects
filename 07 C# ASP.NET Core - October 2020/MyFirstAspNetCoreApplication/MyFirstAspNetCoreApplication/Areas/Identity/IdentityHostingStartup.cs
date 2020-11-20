using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyFirstAspNetCoreApplication.Areas.Identity.IdentityHostingStartup))]
namespace MyFirstAspNetCoreApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}