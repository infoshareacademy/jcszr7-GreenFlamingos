using GreenFlamingos.Model.APIResponses;
using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GreenFlamingosWebApp.Controllers
{
    public class DrinkServiceController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkServiceController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<ActionResult> ApiComm(string alcoType)
        {
            var client = new HttpClient();
            var responseObject = new IngredientResponse();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://the-cocktail-db.p.rapidapi.com/search.php?i={alcoType}"),
                Headers =
            {
                { "X-RapidAPI-Key", "6644d4071bmsh563adbf6d3e9af9p166644jsn00e21c66c99d" },
                { "X-RapidAPI-Host", "the-cocktail-db.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                responseObject = JsonConvert.DeserializeObject<IngredientResponse>(body);
            }
            return View(responseObject.Ingredients.First());
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
                ModelState.AddModelError("Name", "Podany składnik jest już w bazie danych");
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
