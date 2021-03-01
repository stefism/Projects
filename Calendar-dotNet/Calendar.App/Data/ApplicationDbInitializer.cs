using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Calendar.App.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync
                ("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "Admin".ToUpper();
                roleManager.CreateAsync(role).Wait();
            }

            if (userManager.FindByEmailAsync("admin@proba.net").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@proba.net",
                    Email = "admin@proba.net"
                };

                var result = userManager.CreateAsync(user, "Proba_123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("user@proba.net").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "user@proba.net",
                    Email = "user@proba.net"
                };

                var result = userManager.CreateAsync(user, "Proba_123").Result;
            }
        }
    }
}
