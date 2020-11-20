using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApplication.ViewModels.Recipes;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AddMultiple()
        {
            var model = new AddRecipeInputModel
            {
                Type = Models.RecipeType.Unknown,
                FirstCooked = DateTime.UtcNow,
                Time = new RecipeTimeInputModel
                {
                    CookingTime = 10,
                    PreparationTime = 5,
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMultiple(AddRecipeInputModel input)
        {
            if (!input.Images.FirstOrDefault()?.FileName.EndsWith(".svg") == true)
            {
                ModelState.AddModelError("Image", "Invalid file type."); 
            }

            if (input.Images.FirstOrDefault()?.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "Image size is too big.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            using (FileStream fs = new FileStream(webHostEnvironment.WebRootPath + "/user.svg", FileMode.Create))
            {
                await input.Images.FirstOrDefault()?.CopyToAsync(fs);
            }

            return Redirect(nameof(ThankYou));
        }

        public IActionResult Add()
        {
            var model = new AddRecipeInputModel
            {
                Type = Models.RecipeType.Unknown,
                FirstCooked = DateTime.UtcNow,
                Time = new RecipeTimeInputModel
                {
                    CookingTime = 10,
                    PreparationTime = 5,
                }
            };
            //Когато искаме при първоначално зареждане на формата да имаме предварително попълнени делолтни данни, тогава си правим модел, слагаме данните в модела и подаваме модела на вюто.

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeInputModel input)
        {
            //Атрибута [FromBody] указан преди името на параметъра в конструктора, ни позволява да прочетем от бодито на заявката нещото, когато то е Json.
            //[Bind "<Param1>, <Param2>, ...."] указваме точно кои пропертита искаме. Това само ако не искаме да вземе всички пропертита, които се подават, а само някои.

            if (!input.Image.FileName.EndsWith(".svg"))
            {
                ModelState.AddModelError("Image", "Invalid file type."); //Добавяме грешка към модела, която се отнася за Image пропертито. Тази проверка е хубаво да я направим на валидационен атрибут и да ся поставим върху пропертито, а не тук.
            }

            if (input.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "Image size is too big.");
            }

            if (!ModelState.IsValid)
            {
                return View(); //Ако нещо не е валидно, връщаме потребителя пак към вюто за да си допопълни вярно данните.
            }

            using (FileStream fs = new FileStream(webHostEnvironment.WebRootPath + "/user.svg", FileMode.Create))
            {
                await input.Image.CopyToAsync(fs);
            }

            return Redirect(nameof(ThankYou)); //Ако всичко е вярно попълнено, най-често го препращаме към друга страница. - Get -> Post -> Redirect.
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [Authorize(Roles = "Admin")] // Този екшън ще е достъпен само за логнат потребител в роля Admin.
        public IActionResult Image()
        {
            return PhysicalFile(webHostEnvironment.WebRootPath + "/user.svg", "image/png");
        }
    }
}
