using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model.Users;
using GreenFlamingos.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
                    var ingredientToAdd = new Ingredient { Id = userIngredients.IndexOf(ingredient)+1, Name = ingredient,Capacity = userIngredientsCapacity[userIngredients.IndexOf(ingredient)] };
                    drink.Ingredients.Add(ingredientToAdd);
                }
                var mainIngredients = await _drinkService.GetAllMainIngredients();
                ViewBag.MainIngredients = mainIngredients.Select(m => m.Name).ToList();
                var drinkTypes = await _drinkService.GetAllDrinkTypes();
                ViewBag.DrinkType = drinkTypes.Select(dt => dt.Name).ToList();
                
                await _drinkService.AddDrink(drink);
                return RedirectToAction(nameof(Index));
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
        public ActionResult AddRating(IFormCollection rating)
        {
            var stars = rating["rating"].ToString();
            var formValues = stars.Split(',');
            var rateToAdd = float.Parse(formValues[0]);
            var drinkId = int.Parse(formValues[1]);
            var drink = _drinkService.GetDrinkById(drinkId);
            return RedirectToAction(nameof(Index));
        }
    }
}
