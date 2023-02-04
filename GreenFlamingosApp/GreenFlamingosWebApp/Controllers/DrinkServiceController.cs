﻿using GreenFlamingos.Services.Services.Interfaces;
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
