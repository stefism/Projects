using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddleWareDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/softuni", app =>
            {
                app.Map("/welcome",
                app => app.UseWelcomePage();
                app.Run(async (request) =>
                await request.Response.WriteAsync("Other page."));
            }); //Само за конкретния адрес ще важат собствени мидълуери.

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello-1.");
                
                if (DateTime.Now.Second % 2 == 0)
                {
                    await next(); // Ако не викнем некст, надолу методите няма да се изпълнят. Нарича се късо съединение или short-circuit.
                }
                
                await context.Response.WriteAsync("Hello-4.");
            }); //Целия този метод се нарича рикуест делегат.

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello-2.");                
                await context.Response.WriteAsync("Hello-3.");
            });

            app.Run(async (request) =>
            {
                await request.Response.WriteAsync("С Run се обозначава последния мидълуер. След него няма повече и той няма метода next."); // Ако има други след този, те няма да се изпълнят.               
            });
        }
    }
}
