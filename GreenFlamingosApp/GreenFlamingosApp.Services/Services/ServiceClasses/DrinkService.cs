﻿using GreenFlamingos.Model.Drinks;
using Microsoft.AspNetCore.Hosting;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingos.Services.Services.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces;
using System.Security.Claims;

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
        public async Task<bool> AreDrinkIngredientsInDb(List<Ingredient> ingredients)
        {
            var ingredientCounter = 0;
            foreach (var ingredient in ingredients)
            {
                var ingredientInDb = await _drinkRepository.CheckIngredientByName(ingredient.Name);
                if (ingredientInDb)
                    ingredientCounter++;
            }

            if (ingredientCounter == ingredients.Count())
            {
                return true;
            }

            return false;

        }
        public async Task<List<DbIngredient>> CreateIngredientsList(List<Ingredient> ingredients)
        {
            var dbIngredients = new List<DbIngredient>();
            foreach (var ingredient in ingredients)
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

            if (await AreDrinkIngredientsInDb(newDrink.Ingredients))
            {
                dbIngredients = await CreateIngredientsList(newDrink.Ingredients);
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

            if (await AreDrinkIngredientsInDb(drink.Ingredients))
            {
                dbIngredients = await CreateIngredientsList(drink.Ingredients);
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
        public async Task<List<Drink>> GetSearchedDrinks(string searchedPhrase)
        {
            if (searchedPhrase != null)
            {
                var dbDrinks = await _drinkRepository.GetAllDrinks();
                return dbDrinks.Where(d => d.Name.Contains(searchedPhrase)).ToList();
            }
            else
            {
                return await _drinkRepository.GetAllDrinks();
            }
        }

        public Dictionary<string, string> GetCommentsList(DbDrink dbDrink)
        {
            return dbDrink.DrinkUsers.Where(d => d.DrinkId == dbDrink.Id).ToDictionary(du => du.User.UserName, du => du.Comment);
        }

        public async Task<List<Drink>> GetDrinksByMainIngredient(string mainIngredient)
        {
            var dbDrinks = await _drinkRepository.GetDbDrinksByMainIngredient(mainIngredient);

            var dictonaryRating = await _drinkRepository.GetDrinkIdRatingDicotnary();

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
                Comments = GetCommentsList(dbDrinks),
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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

        public async Task AddCommentToDrink(int drinkId, Claim userId, string commentText)
        {
            var drinkToRate = await _drinkRepository.GetDrinkById(drinkId);
            var user = await _userAutentication.GetUserById(userId);
            await _drinkRepository.AddCommentToDrink(user, drinkToRate, commentText);
        }
        public async Task<Dictionary<DbDrink, decimal>> GetTopRatedDrinks()
        {
            return await _drinkRepository.GetTopRatedDrinks();
        }

        public async Task<Dictionary<DbDrink, decimal>> Get6TopRatedDrinks()
        {
            return await _drinkRepository.Get6TopRatedDrinks();
        }
        public async Task<List<Drink>> GetFavouriteDrinks(Claim userId)
        {
            var user = await _userAutentication.GetUserById(userId);
            var model = await _drinkRepository.GetFavouriteDrinks(user);
            var dictonaryRating = await _drinkRepository.GetDrinkIdRatingDicotnary();
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
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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

        public async Task<List<Drink>> GetMatchedDrinks(DrinkMatch drinkToMatch)
        {
            var dbDrinksMatched = await _drinkRepository.GetMatchedDrinks(drinkToMatch);
            var dictonaryRating = await _drinkRepository.GetDrinkIdRatingDicotnary();
            return dbDrinksMatched.Select(dbDrinks => new Drink
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
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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

        public async Task<List<Drink>> GetDrinksShotByMainIngredient(string mainIngredient)
        {
            var dbDrinks = await _drinkRepository.GetDbDrinksShotsByMainIngredient(mainIngredient);

            var dictonaryRating = await _drinkRepository.GetDrinkIdRatingDicotnary();

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
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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

        public async Task<List<Drink>> GetDrinksNoAlcoByMainIngredient(string mainIngredient)
        {
            var dbDrinks = await _drinkRepository.GetDbDrinksNoAlcoByMainIngredient(mainIngredient);

            var dictonaryRating = await _drinkRepository.GetDrinkIdRatingDicotnary();

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
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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

        public async Task<bool> AddIngredientsToDB(List<Ingredient> ingredients)
        {
                var IsIngredientInDB = await AreDrinkIngredientsInDb(ingredients);
                if(!IsIngredientInDB)
                {
                    var dbIngredients = ingredients.Select(i => new DbIngredient { Name = i.Name }).ToList();
                    await _drinkRepository.AddIngredientsToDB(dbIngredients);
                    return true;
                }
            return false;
        }

        public async Task<bool> AddProposedDrink(Drink newDrink)
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

            if (await AreDrinkIngredientsInDb(newDrink.Ingredients))
            {
                dbIngredients = await CreateIngredientsList(newDrink.Ingredients);
            }
            else
            {
                return false;
            }

            var drinkToAdd = new DbProposedDrink
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

            await _drinkRepository.AddProposedDrinkToDB(drinkToAdd, dbIngredients, ingredientsCapacity);
            return true;
        }
        public async Task<List<Drink>> GetAllProposedDrinks()
        {
            var drinks = await _drinkRepository.GetAllProposedDrinks();
            return drinks;
        }
        public async Task<Drink> GetProposedDrinkById(int id)
        {
            var drinks = await GetAllProposedDrinks();
            return drinks.FirstOrDefault(d => d.Id == id);
        }
        public async Task RemoveProposedDrink(Drink drink)
        {
            await _drinkRepository.RemoveProposedDrinkFromDB(drink.Id);
        }
    }
}
