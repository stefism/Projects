using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync
            (List<Route> routeTable, int port = 80)
        {
            IHttpServer server = new HttpServer();

            foreach (var route in routeTable)
            {
                server.AddRoute(route.Path, route.Action);
            }

            //Process.Start(@"C:\Program Files\Opera\launcher.exe", "http://localhost");

            await server.StartAsync(port);
        }
    }
}
