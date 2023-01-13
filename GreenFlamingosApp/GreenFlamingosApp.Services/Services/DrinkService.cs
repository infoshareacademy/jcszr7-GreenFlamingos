using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using GreenFlamingos.Repository;
using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Cryptography.X509Certificates;

namespace GreenFlamingos.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DrinkRepository _drinkRepository;
        public DrinkService(IWebHostEnvironment webHostEnvironment, DrinkRepository drinkRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _drinkRepository = drinkRepository;
        }
        public async Task<List<MainIngredient>> GetAllMainIngredients()
        {
            var dbMainIngredients =  await _drinkRepository.GetAllDbMainIngredients();
            return dbMainIngredients.Select(m => new MainIngredient { Id = m.Id, Name = m.Name }).ToList();
        }
        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var dbIngredients =  await _drinkRepository.GetAllDbIngredients();
            return dbIngredients.Select(i=>new Ingredient { Id = i.Id, Name = i.Name }).ToList();
        }
        public async Task<List<DrinkType>> GetAllDrinkTypes()
        {
            var dbDrinkTypes =  await _drinkRepository.GetAllDbDrinkTypes();
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
        public async Task AddDrink(Drink newDrink)
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

            //delete when user services will be added
            Random rand = new Random();
            var randuserId = rand.Next(1, 2);
            var drinkAuthor = await _drinkRepository.GetUserById(randuserId);
            var drinkToAdd = new DbDrink { 
                Name = newDrink.Name,
                Capacity = newDrink.Capacity,
                AlcoholContent = newDrink.AlcoholContent,
                Calories = newDrink.Calories,
                DrinkType = drinkType,
                MainIngredient = mainIngredient,
                Preparations = newDrink.Preparation,
                Description = newDrink.Description,
                ImageUrl = newDrink.ImageUrl,
                Author = drinkAuthor,
            };

            await _drinkRepository.AddDrinkToDb(drinkToAdd,dbIngredients, ingredientsCapacity);
        }
        public async Task EditDrink(Drink drink)
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

            //Delete this after user func.
            Random rand = new Random();
            var randuserId = rand.Next(1, 2);
            var drinkAuthor = await _drinkRepository.GetUserById(randuserId);

            drinkToEdit.Name = drink.Name;
            drinkToEdit.Calories = drink.Calories;
            drinkToEdit.Description = drink.Description;
            drinkToEdit.Preparations = drink.Preparation;
            drinkToEdit.AlcoholContent = drink.AlcoholContent;
            drinkToEdit.DrinkType = drinkType;
            drinkToEdit.MainIngredient = mainIngredient;
            drinkToEdit.Author = drinkAuthor;
            drinkToEdit.ImageUrl = drink.ImageUrl;

           await _drinkRepository.EditDrinkinDB(drinkToEdit, dbIngredients, ingredientsCapacity);

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
        public List<Drink> SearchDrink(string searchedWord)
        {
            if (searchedWord != null)
                return DrinkRepository.drinkList.Where(d => d.Name.Contains(searchedWord)).ToList();
            return DrinkRepository.drinkList;
        }

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
    }
}
