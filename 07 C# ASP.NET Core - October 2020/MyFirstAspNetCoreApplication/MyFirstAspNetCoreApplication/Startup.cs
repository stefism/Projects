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
            //�� ������������ �� JWToken:
            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //���������� �� ���. � ������ ������.
            services.AddMemoryCache();

            // ���������� �� Distributed ���.
            services.AddDistributedSqlServerCache(opt =>
            {
                opt.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                opt.SchemaName = "dbo";
                opt.TableName = "CacheRecords";
            });

            //���������� �� �����;
            // ������ ����� ���, �� �� ������ � middleware � Configure ������!
            services.AddSession(opt => 
            {
                opt.IdleTimeout = new TimeSpan(365, 0, 0, 0); // ����� ����� �� �� ���� ������������. ��� �� �� �� ������ �����, �� �� ���� �� ����������� �� �������.
                opt.Cookie.HttpOnly = true; //��������� ��������� �� �� �� ����� �� JavaScript. ������������! �� �� �������� ����� ������� � �� �� ��������� �� �����������.
                opt.Cookie.IsEssential = true; //������� ����� � ��� ������������ �� �����������.
            });
            //��������� ���������� �� ���� � Distributed cach, ������ ����� �� �� ������ �����, ������ Distributed cach �� ���� ���������� � �� ��� ��������� ������� �� ���� � ������.

            //Configure JWT autentication
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>(); //JwtSettings - ����, ����� ��� ��� �� ���������.
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret); //jwtSettings.Secret - ���������� � ����� ����. �� � ������� ��� �������� JwtSettings (����� ��� �� ����������) � appsettings.json �  � ��� � ������� Secret �����, ����� ��� �� �� ���������� ����� �� ����.

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                //����� �������� � ��������� �� ��������:
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                //���������� �� ������������ �� ������� ���� ��������� ���� ���������� ����� �� �������:
                options.Lockout.MaxFailedAccessAttempts = 5;

                //����� �� ������� �� ����� ������ �� ����� ������� �� � �������� ��� ��������� ���� ���������� ��������:
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);

            })
                .AddRoles<IdentityRole>() // ������������ ������ �� �� ������ �� �� ����� ����!
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddControllersWithViews(); //��� ����������� �� ������.

            services.AddAuthentication(opt => 
            {
                //��� ������ �������� ������������ � JWT, �� ����� ���
                //opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                
                //��� ����� ������������ ��� �������.
                .AddFacebook(opt => 
            {
                opt.AppId = "817785375686900";
                opt.AppSecret = "....";
            })
                //��������� �� JWT - � ��� ����.
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
                configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); //������������ ��� ����� ���������� �� �� �� ��������� �� ���� ���� ������� �������� �����!
            });
            //�������� ������ �� �� �����������. ������ �� �������� � �������� � ����� ���. ������ �� ��������, ������� ������� �� ����� ���� �����.

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ��� ������ ����������� �� �� ������� ���� ��� ������������ �� ������������:
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
            // ---- ���-����� � ���� �� �� ������ � ������� ���� � ������ �� �� ����� ������.

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

            //�� ���������� �� �����, ������ �� �� ������ � ���� ���, ����� ����������� � ������ �����.
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Home/StatusCodeError?errorCode={0}"); // ��� ������ �� ����������� ��� ������ �� ���� �� ��������. ���� � ��� ������ ��� ���� �� ����� ����.

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
