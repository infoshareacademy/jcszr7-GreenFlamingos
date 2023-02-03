using GreenFlamingos.Model.Drinks;
using Microsoft.AspNetCore.Hosting;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingos.Services.Services.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenFlamingosApp.Services.Services.ServiceClass
{
    public class DrinkService : IDrinkService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDrinkRepository _drinkRepository;
        private readonly IUserAutentication _userAutentication;
        public DrinkService(IWebHostEnvironment webHostEnvironment, IDrinkRepository drinkRepository, IUserAutentication userAutentication)
        {
            _webHostEnvironment = webHostEnvironment;
            _drinkRepository = drinkRepository;
            _userAutentication = userAutentication;
        }
        public async Task<List<MainIngredient>> GetAllMainIngredients()
        {
            var dbMainIngredients = await _drinkRepository.GetAllDbMainIngredients();
            return dbMainIngredients.Select(m => new MainIngredient { Id = m.Id, Name = m.Name }).ToList();
        }
        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var dbIngredients = await _drinkRepository.GetAllDbIngredients();
            return dbIngredients.Select(i => new Ingredient { Id = i.Id, Name = i.Name }).ToList();
        }
        public async Task<List<DrinkType>> GetAllDrinkTypes()
        {
            var dbDrinkTypes = await _drinkRepository.GetAllDbDrinkTypes();
            return dbDrinkTypes.Select(dt => new DrinkType { Id = dt.Id, Name = dt.Name }).ToList();
        }
        public async Task<bool> AreDrinkIngredientsInDb(Drink drink)
        {
            var ingredientCounter = 0;
            foreach (var ingredient in drink.Ingredients)
            {
                var ingredientInDb = await _drinkRepository.CheckIngredientByName(ingredient.Name);
                if (ingredientInDb)
                    ingredientCounter++;
            }

            if (ingredientCounter == drink.Ingredients.Count())
            {
                return true;
            }

            return false;

        }
        public async Task<List<DbIngredient>> CreateIngredientsList(Drink drink)
        {
            var dbIngredients = new List<DbIngredient>();
            foreach (var ingredient in drink.Ingredients)
            {
                var dbIngredient = await _drinkRepository.GetIngredientByName(ingredient.Name);
                dbIngredients.Add(dbIngredient);
            }

            return dbIngredients;
        }
        public async Task<bool> AddDrink(Drink newDrink)
        {
            if (newDrink.Photo != null)
            {
                var folder = "Drinks/";
                folder += Guid.NewGuid().ToString() + "_" + newDrink.Photo.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                newDrink.ImageUrl = "/" + folder;
                newDrink.Photo.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            var mainIngredient = await _drinkRepository.GetMainIngredientByName(newDrink.MainIngredient);
            var drinkType = await _drinkRepository.GetDrinkTypeByName(newDrink.DrinkType);

            var ingredientsCapacity = newDrink.Ingredients.Select(i => i.Capacity).ToList();

            var dbIngredients = new List<DbIngredient>();

            if (await AreDrinkIngredientsInDb(newDrink))
            {
                dbIngredients = await CreateIngredientsList(newDrink);
            }
            else
            {
                return false;
            }

            var drinkToAdd = new DbDrink
            {
                Name = newDrink.Name,
                Capacity = newDrink.Capacity,
                AlcoholContent = newDrink.AlcoholContent,
                Calories = newDrink.Calories,
                DrinkType = drinkType,
                MainIngredient = mainIngredient,
                Preparations = newDrink.Preparation,
                Description = newDrink.Description,
                ImageUrl = newDrink.ImageUrl,
                Author = null,
            };

            await _drinkRepository.AddDrinkToDb(drinkToAdd, dbIngredients, ingredientsCapacity);
            return true;
        }
        public async Task<bool> EditDrink(Drink drink)
        {
            var folder = "Drinks/";
            folder += Guid.NewGuid().ToString() + "_" + drink.Photo.FileName;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            drink.ImageUrl = "/" + folder;
            drink.Photo.CopyTo(new FileStream(serverFolder, FileMode.Create));


            var drinkToEdit = await _drinkRepository.GetDrinkById(drink.Id);

            var mainIngredient = await _drinkRepository.GetMainIngredientByName(drink.MainIngredient);
            var drinkType = await _drinkRepository.GetDrinkTypeByName(drink.DrinkType);

            var ingredientsCapacity = drink.Ingredients.Select(i => i.Capacity).ToList();

            var dbIngredients = new List<DbIngredient>();

            if (await AreDrinkIngredientsInDb(drink))
            {
                dbIngredients = await CreateIngredientsList(drink);
            }
            else
            {
                return false;
            }
            drinkToEdit.Name = drink.Name;
            drinkToEdit.Calories = drink.Calories;
            drinkToEdit.Description = drink.Description;
            drinkToEdit.Preparations = drink.Preparation;
            drinkToEdit.AlcoholContent = drink.AlcoholContent;
            drinkToEdit.DrinkType = drinkType;
            drinkToEdit.MainIngredient = mainIngredient;
            drinkToEdit.Author = null;
            drinkToEdit.ImageUrl = drink.ImageUrl;

            await _drinkRepository.EditDrinkinDB(drinkToEdit, dbIngredients, ingredientsCapacity);
            return true;

        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            var drinks = await _drinkRepository.GetAllDrinks();
            return drinks;
        }
        public async Task<Drink> GetDrinkById(int id)
        {
            var drinks = await GetAllDrinks();
            return drinks.FirstOrDefault(d => d.Id == id);
        }
        public async Task RemoveDrink(Drink drink)
        {
            await _drinkRepository.RemoveDrinkFromDB(drink.Id);
        }
        //public List<Drink> SearchDrink(string searchedWord)
        //{
        //    if (searchedWord != null)
        //        return DataBaseDrinkService.drinkList.Where(d => d.Name.Contains(searchedWord)).ToList();
        //    return Repository.DataBaseDrinkService.drinkList;
        //}
        public async Task<List<Drink>> GetDrinksByMainIngredient(string mainIngredient)
        {
            var dbDrinks = await _drinkRepository.GetDbDrinksByMainIngredient(mainIngredient);

            return dbDrinks.Select(dbDrinks => new Drink
            {
                Id = dbDrinks.Id,
                Name = dbDrinks.Name,
                DrinkType = dbDrinks.DrinkType.Name,
                MainIngredient = dbDrinks.MainIngredient.Name,
                Capacity = dbDrinks.Capacity,
                AlcoholContent = dbDrinks.AlcoholContent,
                Preparation = dbDrinks.Preparations,
                Calories = dbDrinks.Calories,
                Description = dbDrinks.Description,
                ImageUrl = dbDrinks.ImageUrl,
                Ingredients = dbDrinks.DrinkIngredients.Select(i => new
                {
                    SimplyIngredient = i.Ingredient,
                    SimplyIngredientCapacity = i.IngredientCapacity
                })
                                                       .Select(x => new Ingredient
                                                       {
                                                           Name = x.SimplyIngredient.Name,
                                                           Capacity = x.SimplyIngredientCapacity
                                                       }).ToList()
            }).ToList();
        }
        public async Task AddDrinkToFavourites(int drinkId, Claim userId)
        {
            var drinkToFvourites = await _drinkRepository.GetDrinkById(drinkId);
            var user = await _userAutentication.GetUserById(userId);
            await _drinkRepository.AddDrinkToFavourites(user, drinkToFvourites);
        }
        public async Task AddRateToDrink(int drinkId, Claim userId, int rateToAdd)
        {
            var drinkToRate = await _drinkRepository.GetDrinkById(drinkId);
            var user = await _userAutentication.GetUserById(userId);
            await _drinkRepository.AddRateToDrink(user, drinkToRate, rateToAdd);
        }
        public async Task<Dictionary<DbDrink, int>> GetTopRatedDrinks()
        {
            return await _drinkRepository.GetTopRatedDrinks();
        }
        public async Task<List<Drink>> GetFavouriteDrinks(Claim userId)
        {
            var user = await _userAutentication.GetUserById(userId);
            var model = await _drinkRepository.GetFavouriteDrinks(user);

            return model.Select(dbDrinks => new Drink
            {
                Id = dbDrinks.Id,
                Name = dbDrinks.Name,
                DrinkType = dbDrinks.DrinkType.Name,
                MainIngredient = dbDrinks.MainIngredient.Name,
                Capacity = dbDrinks.Capacity,
                AlcoholContent = dbDrinks.AlcoholContent,
                Preparation = dbDrinks.Preparations,
                Calories = dbDrinks.Calories,
                Description = dbDrinks.Description,
                ImageUrl = dbDrinks.ImageUrl,
                Ingredients = dbDrinks.DrinkIngredients.Select(i => new
                {
                    SimplyIngredient = i.Ingredient,
                    SimplyIngredientCapacity = i.IngredientCapacity
                })
                                                       .Select(x => new Ingredient
                                                       {
                                                           Name = x.SimplyIngredient.Name,
                                                           Capacity = x.SimplyIngredientCapacity
                                                       }).ToList()
            }).ToList();
        }
    }
}
