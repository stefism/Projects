using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    //За активация на JWToken се инсталира Microsoft.AspNetCore.Autentication.JwtBearer
    public class IdentityTestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityTestController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager; //Задължително за да имаме роли, в StartUp -> ConfigureServices трябва да добавим -> .AddRoles<IdentityRole>() 
        }

        public async Task<IActionResult> LoginUser()
        {
            var result = await signInManager.PasswordSignInAsync("usera123", "userPassword", true, true);

            return Json(result);
        }

        public async Task<IActionResult> LogoutUser()
        {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }

        public async Task<IActionResult> CreateNewUser()
        {
            var user = new ApplicationUser
            {
                Email = "user1@abv.bg",
                UserName = "usera123",
                PhoneNumber = "5689778",
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, "userPassword");

            if (!result.Succeeded)
            {
                return Json(result.Errors);
            }

            return Json(result);
        }

        [Authorize(Roles = "Admin, Teacher, Student")] //Само логнат потребител може да достъпва тази страница. Ако потребителя не се е логнал, го праща на логин страницата за да се логне. Roles = "Admin" е допълнителна опция. Пише се само ако искаме да ограничиме юзера да бъде и в определна роля за да достъпи страницата.
        //Можем да изброяваме повече от една роля.
        public async Task<IActionResult> WhoAmI()
        {
            var user = await userManager.GetUserAsync(User);
            IList<string> roles = await userManager.GetRolesAsync(user); //Евентуално ако ни трябва, можем да видим всички роли.

            return Json(user);
        }

        public async Task<IActionResult> AddUserToAdmin()
        {
            //За да добавим потребител в роля, първо трябва да я създадем.

            //Когато добавим роля към потребител, задължелно потребителя трябва да излезе и да влезе пак в сайта за да може да му се ъпдейтне бисквитката с ролята и да получи правата!

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

            var user = await userManager.GetUserAsync(User);
            var result = await userManager.AddToRoleAsync(user, "Admin");

            return Json(result);
        }

        public async Task<IActionResult> AddClaim()
        {
            var user = await userManager.GetUserAsync(User);

            var result = await userManager.AddClaimAsync(user, new Claim("City", "Sofia"));

            return Json(result);
        }
    }
}
