
using GreenFlamingosWebApp.Models;
using GreenFlamingosWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenFlamingosWebApp.Controllers
{
    public class DrinkController : Controller
    {
        // GET: DrinkController

        private readonly IDrinkService _drinkService;
        
        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        public ActionResult Index()
        {
            var model = _drinkService.GetAll();
            return View(model);
        }

        // GET: DrinkController/Details/5
        public ActionResult Details(int id)
        {
            var model = _drinkService.GetDrinkById(id);
            return View(model);
        }

        // GET: DrinkController/Create
        public ActionResult Create()
        {
            ViewBag.MainIngredients = new List<string> { "Rum", "Wódka", "Whisky" };
            ViewBag.DrinkType = new List<string> { "Drink", "Shot", "Koktajl" };
            return View();
        }

        // POST: DrinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Drink drink, IFormCollection preparation, IFormCollection ingredients)
        {
            try
            {
                string recipy = preparation["Preparation"];
                string components = ingredients["Ingredients"];
                drink.Ingredients = components.Split(",").ToList();
                drink.Preparation = recipy.Split(",").ToList();
                ViewBag.MainIngredients = new List<string> { "Rum", "Wódka", "Whisky" };
                ViewBag.DrinkType = new List<string> { "Drink", "Shot", "Koktajl" };
                _drinkService.AddDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: DrinkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: DrinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
