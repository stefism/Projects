using Calendar.App.Services;
using Calendar.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Calendar.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDataService dataService;
        private readonly IPriceService priceService;

        public HomeController(
            ILogger<HomeController> logger,
            RoleManager<IdentityRole> roleManager,
            IDataService dataService,
            IPriceService priceService)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.dataService = dataService;
            this.priceService = priceService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await priceService.ReturnPrices();
            var userId = string.Empty;

            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            else
            {
                return View();
            }

            model.UsersReservations = await dataService.ShowUserReservations(userId);
            
            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> ChangePrices([FromBody] ChangePricesInputModel input)
        {
            await dataService.ChangePrices(input.Workday, input.Weekends);

            //return RedirectToAction(nameof(Index));
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));

            return RedirectToAction(nameof(Privacy));
        }
    }
}
