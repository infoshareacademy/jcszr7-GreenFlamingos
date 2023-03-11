using GreenFlamingos.Services.Services.Interfaces;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.Services.Services.ServiceClass;
using GreenFlamingosWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GreenFlamingosWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<DbUser> _signInManager;
        private readonly UserManager<DbUser> _userManager;
        private readonly IDrinkService _drinkService;


        public HomeController(SignInManager<DbUser> signInManager, UserManager<DbUser> userManager, IDrinkService drinkService )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _drinkService = drinkService;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            }
            var topRated = await _drinkService.Get6TopRatedDrinks();
            return View(topRated);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}