using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Services.Interfaces;
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
            var test = _drinkService.GetAllMainIngredient();
            ViewBag.MainIngredients = test.Select(m=>m.Name).ToList();
            ViewBag.DrinkType = new List<string> { "Drink", "Shot", "Koktajl" };
            return View();
        }

        // POST: DrinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Drink drink)
        {
            try
            {
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
            ViewBag.MainIngredients = new List<string> { "Rum", "Wódka", "Whisky" };
            ViewBag.DrinkType = new List<string> { "Drink", "Shot", "Koktajl" };
            var model = _drinkService.GetDrinkById(id);
            return View(model);
        }
        // POST: DrinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Drink drink)
        {
            try
            {
                ViewBag.MainIngredients = new List<string> { "Rum", "Wódka", "Whisky" };
                ViewBag.DrinkType = new List<string> { "Drink", "Shot", "Koktajl" };
                _drinkService.EditDrink(drink);
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
            var model = _drinkService.GetDrinkById(id);
            return View(model);
        }

        // POST: DrinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Drink drink)
        {
            try
            {
                _drinkService.RemoveDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Search
        public ActionResult Search(string searchedWord)
        {
            var model = _drinkService.SearchDrink(searchedWord);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRating(IFormCollection rating)
        {
            var stars = rating["rating"].ToString();
            var formValues = stars.Split(',');
            var rateToAdd = float.Parse(formValues[0]);
            var drinkId = int.Parse(formValues[1]);
            var drink = _drinkService.GetDrinkById(drinkId);
            drink.Ratings.Add(rateToAdd);
            drink.AverageRating = drink.Ratings.Average();
            return RedirectToAction(nameof(Index));
        }
    }
}
