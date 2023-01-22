using GreenFlamingosApp.DataBase.DbModels;
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

        public HomeController(SignInManager<DbUser> signInManager, UserManager<DbUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            }
            return View();
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