using GreenFlamingos.Model.Users;
using GreenFlamingosWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GreenFlamingosWebApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public ActionResult Index(User user)
        {
            return View(user);
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