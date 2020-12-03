using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MyFirstAspNetCoreApplication.Data;
using MyFirstAspNetCoreApplication.Models;
using MyFirstAspNetCoreApplication.Settings;
using System;
using System.Linq;
using System.Text;

namespace MyFirstAspNetCoreApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //За конфигурация за JWToken:
            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //Активиране на Кеш. В случая мемори.
            services.AddMemoryCache();

            // Активиране на Distributed кеш.
            services.AddDistributedSqlServerCache(opt =>
            {
                opt.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                opt.SchemaName = "dbo";
                opt.TableName = "CacheRecords";
            });

            //Активиране на сесия;
            // Трябва освен тук, да се добави и middleware в Configure метода!
            services.AddSession(opt => 
            {
                opt.IdleTimeout = new TimeSpan(365, 0, 0, 0); // Колко време да се пази информацията. Ако не му се зададе време, ще се пази до приключване на сесията.
                opt.Cookie.HttpOnly = true; //Сесийната бисквитка да не се вижда от JavaScript. Задължително! За не открадне някой сесията и да се представи за потребителя.
                opt.Cookie.IsEssential = true; //Ползвай сесия и без разрешението на потребителя.
            });
            //Сесийната информация се пази в Distributed cach, затова преди да се ползва сесия, трябва Distributed cach да бъде активирано и да има направена таблица за кеша в базата.

            //Configure JWT autentication
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>(); //JwtSettings - клас, който ние сме си направили.
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret); //jwtSettings.Secret - пропертито в нашия клас. То е вързано със секцията JwtSettings (която ние си създадохме) в appsettings.json и  в нея е записан Secret ключа, който ние си го измислихме какъв да бъде.

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                //Опции свързани с настройка на паролата:
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                //Активиране на заключването на акаунта след определен брой неправилни опити за влизане:
                options.Lockout.MaxFailedAccessAttempts = 5;

                //Можем да изберем за какъв период от време акаунта да е заключен при определен брой неправилни влизания:
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);

            })
                .AddRoles<IdentityRole>() // Задължително трябва да се добави за да имаме роли!
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddControllersWithViews(); //Без регистрация на филтри.

            services.AddAuthentication(opt => 
            {
                //Ако искаме дефолтна аутентикация с JWT, се прави тук
                //opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                
                //Ако искае аутентикация със Фейсбук.
                .AddFacebook(opt => 
            {
                opt.AppId = "817785375686900";
                opt.AppSecret = "....";
            })
                //Настройки за JWT - и тук също.
                .AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddControllersWithViews(configure =>
            {
                //configure.Filters.Add(new AddHeaderActionFilter());
                configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); //Задължително във всяко приложение за да се предпазим от крос сайт рекуест форджъри атака!
            });
            //Филтрите трябва да се регистрират. Единия от начините е глобално и става тук. Когато са глобални, оказват влияние на всеки един екшън.

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ако искаме автоматично да си направи юзър при стартирането на приложението:
            var userManager = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            if (!userManager.Users.Any(x => x.UserName == "kostov@nikolay.it"))
            {
                userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "kostov@nikolay.it",
                    Email = "kostov@nikolay.it",
                    EmailConfirmed = true,
                }, "kostov@nikolay.it").GetAwaiter().GetResult();
            }
            // ---- Най-добре е това да се изнесе в отделен клас и класът да се казва сиидър.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //За използване на сесия, трябва да се добави и този ред, освен настройките в горния метод.
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Home/StatusCodeError?errorCode={0}"); // Ако искаме да редиректнем при грешка на наша си страница. Това е при статус код като се върне само.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
