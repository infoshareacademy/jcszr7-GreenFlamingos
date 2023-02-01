using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model.Users;
using GreenFlamingos.Services.Services.Interfaces;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace GreenFlamingosWebApp.Controllers
{
    public class DrinkController : Controller
    {
        // GET: DrinkController
        private readonly IDrinkService _drinkService;
        private readonly IValidationService _validationService;
        private readonly UserManager<DbUser> _userManager;
        public DrinkController(IDrinkService drinkService, UserManager<DbUser> userManager, IValidationService validationService)
        {
            _drinkService = drinkService;
            _userManager = userManager;
            _validationService = validationService;
        }
        public async Task<ActionResult> Index()
        {
           var model = await _drinkService.GetAllDrinks();
            return View(model);
        }
        // GET: DrinkController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _drinkService.GetDrinkById(id);
            return View(model);
        }

        // GET: DrinkController/Create
        public async Task<ActionResult> Create()
        {
            var mainIngredients = await _drinkService.GetAllMainIngredients();
            ViewBag.MainIngredients = mainIngredients.Select(m=>m.Name).ToList();
            var drinkTypes = await _drinkService.GetAllDrinkTypes();
            ViewBag.DrinkType = drinkTypes.Select(dt => dt.Name).ToList();
            var ingredients = await _drinkService.GetAllIngredients();
            ViewBag.Ingredients = ingredients.Select(i => i.Name).ToList();
            return View();
        }

        // POST: DrinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(Drink drink, IFormCollection userFormValues)
        {
            try
            {
                var mainIngredients = await _drinkService.GetAllMainIngredients();
                ViewBag.MainIngredients = mainIngredients.Select(m => m.Name).ToList();
                var drinkTypes = await _drinkService.GetAllDrinkTypes();
                ViewBag.DrinkType = drinkTypes.Select(dt => dt.Name).ToList();
                if (! await _validationService.IsDrinkExistInDB(drink.Name))
                {
                    var userIngredients = userFormValues["Ingredients"].ToList();
                    var userIngredientsCapacity = userFormValues["IngredientCapacity"].ToList();
                    var userPreparations = userFormValues["Preparations"].ToList();
                    if (userPreparations.Contains(""))
                    {
                        userPreparations.Remove("");
                    }

                    drink.Preparation = string.Join("\r\n", userPreparations);

                    foreach (var ingredient in userIngredients)
                    {
                        var ingredientToAdd = new Ingredient { Id = userIngredients.IndexOf(ingredient) + 1, Name = ingredient, Capacity = userIngredientsCapacity[userIngredients.IndexOf(ingredient)] };
                        drink.Ingredients.Add(ingredientToAdd);
                    }

                    var result = await _drinkService.AddDrink(drink);
                    if(!result)
                    {
                        ModelState.AddModelError("Ingredients", "Lista składników zawiera taki, który nie znajduje się w bazie. Spróbuj ponownie.");
                        return View();
                    }
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("Name", "Drink o podanej nazwie już istnieje");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var mainIngredients = await _drinkService.GetAllMainIngredients();
            ViewBag.MainIngredients = mainIngredients.Select(m => m.Name).ToList();
            var drinkTypes = await _drinkService.GetAllDrinkTypes();
            ViewBag.DrinkType = drinkTypes.Select(dt => dt.Name).ToList();
            var model = await _drinkService.GetDrinkById(id);
            return View(model);
        }
        // POST: DrinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Drink drink ,IFormCollection userFormValues)
        {
            try
            {
                var userIngredients = userFormValues["Ingredients"].ToList();
                var userIngredientsCapacity = userFormValues["IngredientCapacity"].ToList();
                var userPreparations = userFormValues["Preparations"].ToList();

                    if(userPreparations.Contains(""))
                    {
                        userPreparations.Remove("");
                    }

                drink.Preparation = string.Join("\r\n", userPreparations);

                foreach (var ingredient in userIngredients)
                {
                    if (!ingredient.Equals("",StringComparison.OrdinalIgnoreCase))
                    {
                        var ingredientToAdd = new Ingredient { Id = userIngredients.IndexOf(ingredient) + 1, Name = ingredient, Capacity = userIngredientsCapacity[userIngredients.IndexOf(ingredient)] };
                        drink.Ingredients.Add(ingredientToAdd);
                    }
                }
                var mainIngredients = await _drinkService.GetAllMainIngredients();
                ViewBag.MainIngredients = mainIngredients.Select(m => m.Name).ToList();
                var drinkTypes = await _drinkService.GetAllDrinkTypes();
                ViewBag.DrinkType = drinkTypes.Select(dt => dt.Name).ToList();
                await _drinkService.EditDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _drinkService.GetDrinkById(id);
            return View(model);
        }

        // POST: DrinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Drink drink)
        {
            try
            {
                await _drinkService.RemoveDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Search
        //public ActionResult Search(string searchedWord)
        //{
        //    var model = _drinkService.SearchDrink(searchedWord);
        //    return View(model);
        //}

        [HttpPost]
        public async Task<ActionResult> AddRating(IFormCollection rating)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var stars = rating["rating"].ToString();
            var formValues = stars.Split(',');
            var rateToAdd = int.Parse(formValues[0]);
            var drinkId = int.Parse(formValues[1]);
            await _drinkService.GetDrinkById(drinkId);
            await _drinkService.AddRateToDrink(drinkId, userId, rateToAdd);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> AddDrinkToFavourites(int drinkId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            await _drinkService.AddDrinkToFavourites(drinkId, userId);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<ActionResult> GetFavouriteDrinks()
        {
           var userId = User.FindFirst(ClaimTypes.NameIdentifier);
           var model = await _drinkService.GetFavouriteDrinks(userId);
           return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetTopRatedDrinks()
        {
            return View(await _drinkService.GetTopRatedDrinks());
        }

    }
}
