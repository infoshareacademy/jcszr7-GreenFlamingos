using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenFlamingosWebApp.Controllers
{
    public class DrinkServiceController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkServiceController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet("mainIngredient")]
        public async Task<ActionResult> GetDrinksByMainIngredient(string mainIngredient)
        {
            var model = await _drinkService.GetDrinksByMainIngredient(mainIngredient);
            return View(model);
        }

        public async Task<ActionResult> GetDrinksShotByMainIngredient(string mainIngredient)
        {
            var model = await _drinkService.GetDrinksShotByMainIngredient(mainIngredient);
            return View("GetDrinksByMainIngredient",model);
        }


        [HttpGet]
        public ActionResult AddIngredientsToDB()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddIngredientsToDB(IFormCollection ingredientsToAdd)
        {
            var ingredients = ingredientsToAdd["IngredientsToAdd"].ToList();
            var ingredientsToDb = ingredients.Select(i => new Ingredient { Name = i }).ToList();
            var result = await _drinkService.AddIngredientsToDB(ingredientsToDb);
            if(result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "The specified component is already in the database.");
                return View();
            }
        }
        public async Task<ActionResult> GetDrinksNoAlcoByMainIngredient(string mainIngredient)
        {
            var model = await _drinkService.GetDrinksNoAlcoByMainIngredient(mainIngredient);
            return View("GetDrinksByMainIngredient", model);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetTopRatedDrinks()
        {
            return View(await _drinkService.GetTopRatedDrinks());
        }

        [HttpGet]
        public async Task<ActionResult> Get6TopRatedDrinks()
        {
            return View(await _drinkService.Get6TopRatedDrinks());
        }
    }
}
